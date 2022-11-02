<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesPrintType2.aspx.cs" Inherits="Billing.Accountsbootstrap.SalesPrintType2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1" runat="server">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <script type="text/javascript">
        jQuery(function () {
            jQuery("#inf_custom_someDateField").datepicker();
        });
                

	    
                            
    </script>
    <script type="text/javascript">
        function fixform() {
            if (opener.document.getElementById("aspnetForm").target != "_blank") return;
            opener.document.getElementById("aspnetForm").target = "";
            opener.document.getElementById("aspnetForm").action = opener.location.href;
        }
    </script>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
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
    <script type="text/javascript" language="javascript">
        window.print();
    </script>
</head>
<body onload="window.print()">
    <form id="Form1" runat="server">
    <asp:Panel ID="pnlContents" runat="server">
    <asp:Label ID="lblautomastic" runat="server" Text="N" Visible="false" ></asp:Label>
        <!-- /.row -->
        <%--   <div id="idimglog" runat="server" visible="false">
                            <img width="200px" height="121px" src="../images/BlackForrest.png" />
                            <br />
                        </div>
                        <div id="lblpvtltd" runat="server" visible="false">
                            <asp:Label ID="lblpvtltd1" runat="server" Text="POTHYS Pvt Ltd" Style="font-weight: bold;
                                font-size: x-large" Visible="true"></asp:Label>
                            <br />
                        </div>--%>
        <div align="center">
            <table width="550px">
                <%--<tr style="font-family: Courier New; font-weight:bolder; " >--%>
                <tr style="font-family: Courier New; font-weight: bolder;">
                    <td colspan="2" align="center" style="font-size: x-large;">
                        <asp:Label ID="l2" runat="server" Style="font-weight: bolder; font-size: x-large"
                            Visible="false">INVOICE</asp:Label>
                        <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: 36px"
                            Visible="false"></asp:Label>
                        <br />
                        <div id="idFranchisee" runat="server" visible="false">
                            <asp:Label ID="Label3" runat="server" Style="font-size: x-large">(Franchisee:
                                <asp:Label ID="lblfranchise" runat="server"></asp:Label>)</asp:Label>
                        </div>
                    </td>
                </tr>
                <tr style="font-family: Courier New; font-weight: bold;" align="center">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblAddres" runat="server" Style="font-size: 18px"></asp:Label>
                    </td>
                </tr>
                <tr style="font-family: Courier New; font-weight: bold;" align="center">
                    <td align="center" colspan="2">
                        <asp:Label runat="server" Style="font-size: 18px">STATE CODE:</asp:Label><asp:Label
                            ID="lblStatecode" runat="server" Style="font-size: 18px"></asp:Label>,&nbsp&nbsp&nbsp
                        <asp:Label ID="Label2" runat="server" Style="font-size: 18px">STATE NO:</asp:Label><asp:Label
                            ID="lblstateno" runat="server" Style="font-size: 18px"></asp:Label>
                    </td>
                </tr>
                <tr style="font-family: Courier New; font-weight: bold;">
                    <td colspan="2" align="center">
                        <asp:Label ID="Label4" runat="server" Style="font-size: 18px">Tel No:</asp:Label>
                        <asp:Label ID="lblstoreno" runat="server" Style="font-size: 18px"></asp:Label>
                        <br />
                        <asp:Label ID="lblTINNo" runat="server" Style="font-size: 18px">GSTIN:</asp:Label>
                        <asp:Label ID="lbltin" runat="server" Style="font-size: 18px"></asp:Label>
                        <br />
                        <%--<asp:Label ID="Label9" runat="server" Style="font-size: 18px">FSSAI NO:</asp:Label>--%>
                        <img style="width: 4pc" src="../images/fssailogo.png" />
                        <asp:Label ID="lblfssaino" runat="server" Style="font-size: 18px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label5" runat="server" Style="font-size: 20px; font-weight: bold">TAX INVOICE</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblpaymenttype" Style="font-size: 20px" runat="server"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Style="font-size: 20px">Bill</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr visible="false">
                    <td align="left" style="padding-left: 5px; font-size: 15px; font-weight: bold">
                        <%-- <label>
                            Sales Type:
                        </label>--%>
                        <asp:Label Visible="false" ID="lblsalestype" runat="server"></asp:Label>
                        <asp:Label ID="lblorderno" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td colspan="2" visible="false" align="center" style="font-size: 15px; font-weight: bold">
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: 300">
                    <td align="left" style="padding-left: 5px">
                        <asp:Label ID="lblbillname" runat="server"></asp:Label>
                        <asp:Label ID="lblbillno" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        Date:
                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: 300">
                    <td align="left" style="padding-left: 5px">
                        To:
                        <asp:Label ID="lblcustname" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        <asp:Label ID="lblattender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: 300">
                    <td colspan="2" align="left" style="padding-left: 5px">
                        GSTIN:   <asp:Label ID="lblgstno" Visible="true" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: bold; display: none">
                    <td align="left" style="padding-left: 5px">
                        <label>
                            B-Code</label>
                        <asp:Label ID="billedby" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <label>
                            A-Code</label>
                        <asp:Label ID="atender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table id="Table1" runat="server" style="height: 15px; font-family: Courier New;
                            font-weight: 500; text-transform: uppercase" width="100%; ">
                            <tr>
                                <td align="left" style="font-size: 20px; width: 28%">
                                    HSN/ITEM/QTY
                                </td>
                                <td align="center" style="font-size: 20px; width: 14%">
                                    TAX %
                                </td>
                                <td align="center" style="font-size: 20px; width: 28%">
                                    RATE
                                </td>
                                <td align="center" style="font-size: 20px; width: 30%">
                                    AMOUNT
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding-left: 0px">
                        <div class="table-responsive" id="divPrint" runat="server">
                            <asp:GridView ID="gvPrint" Visible="false" Width="100%" runat="server" AutoGenerateColumns="false"
                                OnRowDataBound="gvPrint_OnRowDataBound" GridLines="none" RowStyle-Wrap="true"
                                ShowHeader="false" RowStyle-Font-Names="Calibri" DataKeyNames="col2" HeaderStyle-Wrap="false">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60%" ItemStyle-Font-Bold="true"
                                        ItemStyle-Font-Size="22px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="javascript:switchViews('dv<%# Eval("col1") %>', 'imdiv<%# Eval("col1") %>');"
                                                style="text-decoration: none;"></a>
                                            <%# Eval("col1")%>
                                            <div id="dv<%# Eval("col2") %>">
                                                <asp:GridView runat="server" ID="gvLiaLedger" Width="100%" CssClass="" GridLines="none"
                                                    Font-Bold="false" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="false">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="" DataField="col1" ItemStyle-Width="14%" ItemStyle-Font-Size="26px" />
                                                        <asp:BoundField HeaderText="" DataField="col2" ItemStyle-Width="14%" ItemStyle-Font-Size="26px" />
                                                        <asp:BoundField HeaderText="" DataField="col3" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Width="12%" ItemStyle-Font-Size="26px" />
                                                        <asp:BoundField HeaderText="" DataField="col4" ItemStyle-HorizontalAlign="Center"
                                                            DataFormatString='{0:f}' ItemStyle-Font-Size="26px" ItemStyle-Width="30%" />
                                                        <asp:BoundField HeaderText="" DataField="col5" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Width="30%" ItemStyle-Font-Size="26px" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="TAX%" Visible="false" DataField="col2" ItemStyle-Font-Bold="true"
                                        ItemStyle-Font-Size="20px" HeaderStyle-HorizontalAlign="Center" />
                                    <%--  <asp:BoundField HeaderText="HSN/Item/Qty TAX%" DataField="col1" HeaderStyle-HorizontalAlign="Center" HtmlEncode="false"
                                    ItemStyle-Font-Size="15px" ItemStyle-Width="50%" />--%>
                                    <%--<asp:BoundField HeaderText="TAX%" DataField="col2" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="20px" HeaderStyle-HorizontalAlign="Center" />--%>
                                    <%--<asp:BoundField HeaderText="GST" DataField="col2" HeaderStyle-HorizontalAlign="Center" />--%>
                                    <%--  <asp:BoundField HeaderText="Rate" DataField="col2" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Font-Size="20px" ItemStyle-Width="20%"  />
                                <asp:BoundField HeaderText="Amount" DataField="col3" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Font-Size="20px" ItemStyle-Width="20%" />--%>
                                    <%--  <asp:BoundField HeaderText="HSN/Item/Qty/GST" DataField="Itemn" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Unit" DataField="PackingUnitText" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString="{0:N0}" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="  Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="100px" DataFormatString="{0:N2}" />
                                <asp:BoundField HeaderText="GST%" DataField="gst" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="S%" HeaderStyle-Width="40px" DataField="cg" ItemStyle-Width="40px"
                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Rate" DataField="UnitPrice" DataFormatString="{0:N2}"
                                    Visible="false" />--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:GridView ID="gvprint_ORder" Visible="false" Width="100%" runat="server" AutoGenerateColumns="false"
                            GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="HSN/Qty" DataField="col1" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Font-Size="15px" />
                                <asp:BoundField HeaderText="Item TAX%" DataField="col2" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="20px" HeaderStyle-HorizontalAlign="Center" />
                                <%--<asp:BoundField HeaderText="GST" DataField="col2" HeaderStyle-HorizontalAlign="Center" />--%>
                                <asp:BoundField HeaderText="Rate" DataField="col3" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Font-Size="15px" />
                                <asp:BoundField HeaderText="Amount" DataField="col4" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Font-Size="15px" />
                                <%--  <asp:BoundField HeaderText="HSN/Item/Qty/GST" DataField="Itemn" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Unit" DataField="PackingUnitText" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString="{0:N0}" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="  Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="100px" DataFormatString="{0:N2}" />
                                <asp:BoundField HeaderText="GST%" DataField="gst" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="S%" HeaderStyle-Width="40px" DataField="cg" ItemStyle-Width="40px"
                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Rate" DataField="UnitPrice" DataFormatString="{0:N2}"
                                    Visible="false" />--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td colspan="2" align="right" style="padding-right: 37px">
                        <asp:Label ID="lblAmount" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr id="tradv" runat="server" visible="false" style="font-weight: bold">
                    <td runat="server" visible="false">
                        <label>
                            Paymode:</label>
                        <asp:Label ID="paymode1" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        <label>
                            Advance:-
                        </label>
                        <asp:Label ID="lbladvance" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr style="font-weight: bold" border="1" id="total" runat="server">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label>
                            Total:-
                        </label>
                        <asp:Label ID="lbltotal" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold" border="1" id="tax" runat="server">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label>
                            Tax 5 %:-
                        </label>
                        <asp:Label ID="lblTax" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-family: Calibri; font-weight: bold" border="1">
                    <td colspan="1" align="left">
                        <label style="font-size: 24px">
                            Total Qty :
                        </label>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="24px"></asp:Label>
                        /
                        <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Size="24px"></asp:Label>
                    </td>
                    <td colspan="2" align="right" style="padding-right: 50px; font-weight: bold">
                        <label style="font-size: 24px">
                            TOTAL AMT:
                        </label>
                        <asp:Label ID="lblGrand" runat="server" Font-Bold="true" Font-Size="24px"></asp:Label>
                    </td>
                    <td colspan="2" runat="server" visible="false" align="right" style="padding-right: 50px">
                        <label style="font-size: medium">
                            SubTotal:
                        </label>
                        <asp:Label ID="lblsubttl" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" visible="false" style="" border="1">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label style="font-size: medium">
                            CGST:
                        </label>
                        <asp:Label ID="lblcgst" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" visible="false" style="" border="1">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label style="font-size: medium">
                            SGST:
                        </label>
                        <asp:Label ID="lblsgst" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr id="iddiscamt" style="" border="1" runat="server" visible="false">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label style="font-size: medium">
                            Discount:
                        </label>
                        <asp:Label ID="lbldiscountamt" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold" border="1">
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trCash" runat="server">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label>
                            Cash Received
                        </label>
                        <asp:Label ID="lblReceived" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trPaid" runat="server">
                    <td colspan="2" align="right" style="padding-right: 50px">
                        <label>
                            Balance Paid
                        </label>
                        <asp:Label ID="lblBal" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr runat="server" id="paydetails" visible="false" style="width: 100%">
                    <td colspan="2">
                        <label style="font-size: 16px; font-weight: bold">
                            Payment Details History:(BOOK NO:
                            <asp:Label ID="lblbookno" runat="server"></asp:Label>)</label>
                        <asp:GridView ID="Gridpaymentdetails" EmptyDataText="No Payment Details" runat="server"
                            Width="100%" AutoGenerateColumns="false" Font-Names="Calibri" Font-Size="16px">
                            <Columns>
                                <asp:BoundField DataField="Billdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Payment Date" />
                                <asp:BoundField DataField="Amount" DataFormatString="{0:###,##0.00}" HeaderText="Paid Amount" />
                                <asp:BoundField DataField="Type" HeaderText="Paid Type" />
                                <asp:BoundField DataField="mod" HeaderText="Pay Mode" />
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr runat="server" id="staxdetails" visible="true" style="width: 100%; font-family: Calibri;
                    font-weight: bold">
                    <td colspan="2">
                        <label id="Label8" runat="server" style="font-size: 16px">
                            Tax Split Up Details :</label>
                        <asp:GridView ID="GridTaxvalue" EmptyDataText="No Tax Split Up Details" runat="server"
                            HeaderStyle-Font-Names="Courier New" Width="100%" AutoGenerateColumns="false"
                            Font-Names="Calibri" Font-Size="20px">
                            <Columns>
                                <asp:BoundField HeaderText="Tax %" DataField="taxvalue" />
                                <asp:BoundField HeaderText="HSN Code" Visible="false" DataField="hsncode" />
                                <asp:BoundField HeaderText="Txbl" DataField="value" />
                                <asp:BoundField HeaderText="CGST" DataField="CGST" />
                                <asp:BoundField HeaderText="SGST" DataField="SGST" />
                                <asp:BoundField HeaderText="Total" DataField="Total" />
                                <%--<asp:BoundField HeaderText="IGST Value" DataField="IGST" />--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr style="font-family: Courier New; font-weight: bold">
                    <td colspan="2" align="left">
                        <label>
                            &nbsp</label><label id="lblamtinwords" style="font-size: 19px; font-weight: bold"
                                runat="server"></label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 2px dotted black;">
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td colspan="2" align="center">
                        <label style="font-size: large">
                            Kindly Refrigerate Our Fresh Cream products</label>
                        <label style="font-size: x-large">
                            For Instant Cake Orders
                        </label>
                        <label runat="server" visible="false" style="font-size: xx-large">
                        </label>
                        <br />
                    </td>
                </tr>
                <%--  <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>--%>
                <tr style="font-family: Courier New; font-weight: bold">
                    <td colspan="2" align="center">
                        <label style="font-size: 20px">
                            * * THANK YOU FOR SHOPPING * *</label>
                    </td>
                </tr>
                <tr style="font-family: Courier New; font-weight: bold">
                    <td colspan="2" align="center">
                        <label style="font-size: 20px">
                            VISIT AGAIN
                        </label>
                    </td>
                </tr>
                <tr runat="server" visible="false" style="font-family: Courier New; font-weight: bold">
                    <td colspan="2" align="center">
                        <label style="font-size: 20px">
                            For FeedBack/Queries - 08571 - 226977</label>
                    </td>
                </tr>
                <tr runat="server" visible="false" id="home">
                    <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For Home Delivery Order xxxxx xxxxx</label>
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            www.Facebook.com/xxxxx</label>
                    </td>
                </tr>
                <%-- <tr>
                    <td colspan="2" align="center">
                        <label style="font-size: large">
                            Kindly Refrigerate Our Fresh Cream products</label><br />
                        <label style="font-size: xx-large">
                           www.blaackforestcakes.com</label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                   <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For FeedBack/Queries 84899-55500</label></td>
                            </tr>
                             <tr runat="server" visible="false" id="home">
                   <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For Home Delivery Order 73733 00355</label></td>
                            </tr>
             <tr><td colspan="2" align="center">
              <label style="font-size: x-large">
                           Book Online Instant Cake Orders 84899-55500 www.Facebook.com/blaackforestcakes</label>
                    </td>
                </tr>--%>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <!-- /.panel -->
        </div>
    </asp:Panel>
    </form>
</body>
</html>
