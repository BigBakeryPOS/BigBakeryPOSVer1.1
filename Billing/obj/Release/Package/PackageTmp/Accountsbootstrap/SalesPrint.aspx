<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesPrint.aspx.cs" Inherits="Billing.Accountsbootstrap.SalesPrint" %>

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
<body style="text-transform:uppercase;font-family:Monospace" onload="window.print()">
    <form id="Form1" runat="server">
    <asp:Panel ID="pnlContents" runat="server">
        <!-- /.row -->
        <div align="center">
        <asp:Label ID="lblwithtime" runat="server" Visible="false" Text="Y" ></asp:Label>
        <asp:Label ID="lblqtyneeded" runat="server" Visible="false" Text="N" ></asp:Label>
        <asp:Label ID="lblPCGST" runat="server" Visible="false" Text="Y" ></asp:Label>
        <asp:Label ID="lblpaymodeshown" runat="server" Visible="false" Text="Y" ></asp:Label>
        <asp:Label ID="lblattendershown" runat="server" Visible="false" Text="Y" ></asp:Label>
        <asp:Label ID="lblownplusfrancheese" runat="server" Visible="false" Text="Y" ></asp:Label>
        
            <table width="500px" style="font-size: x-large; font-family: Monospace;">
                <tr>
                    <td colspan="2" align="center" style="font-size: x-large;">
                        <asp:Label ID="l2" runat="server" Style="font-weight: bolder; font-size: x-large"
                            Visible="false">INVOICE</asp:Label>
                        <div id="idimglog" runat="server" visible="true">
                            <asp:Image ID="log" src='<%#Eval("Image")%>' Style="width: 10pc; margin-left: 0px;"
                                runat="server" />
                            <br />
                        </div>
                        <div id="lblpvtltd" runat="server" visible="false">
                            <asp:Label ID="lblpvtltd1" runat="server" Text="POTHYS Pvt Ltd" Style="font-weight: bold;
                                font-size: x-large" Visible="true"></asp:Label>
                            <br />
                        </div>
                        <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: x-large"
                            Visible="false"></asp:Label>
                        <br />
                        <div id="idFranchisee" runat="server" visible="false">
                            <asp:Label ID="Label3" runat="server" Style="font-size: x-large">(
                                <asp:Label ID="lblfranchise" runat="server"></asp:Label>)</asp:Label>
                            <%--<asp:Label ID="Label2" runat="server" Style="font-size: large">Keestu Mithai</asp:Label>--%>
                            <br />
                        </div>
                        <asp:Label ID="lblAddres" runat="server" Style="font-size: x-large;" Visible="true"></asp:Label><br />
                        <asp:Label ID="lblmobilename" runat="server" Visible="false" Text="Tel No." ></asp:Label>
                        <asp:Label ID="lblmobilename1" runat="server" Visible="false" Text="Mobile No." ></asp:Label>
                        <asp:Label ID="lblstoreno" runat="server" Style="font-size: x-large"></asp:Label>
                        <br />
                        <div id="lblgstdetails" runat="server" visible="false">
                        <asp:Label ID="lblTINNo" runat="server" Style="font-size:  x-large">GSTIN:</asp:Label>
                        <asp:Label ID="lbltin" runat="server" Style="font-size:  x-large"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Style="font-size:  x-large">/ FSSAI NO:</asp:Label>
                        <asp:Label ID="lblfssaino" runat="server" Style="font-size:  x-large"></asp:Label>

                        </div>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label5" runat="server" Style="font-size: 20px; font-weight: bold">TAX INVOICE</asp:Label>
                    </td>
                </tr>
                <tr id="lblpaymodebill" runat="server" visible="false" >
                    <td colspan="2" align="center">
                        <asp:Label ID="lblpaymenttype" Style="font-size: 20px" runat="server"></asp:Label>
                        <asp:Label ID="Labesdl5" runat="server" Style="font-size: 20px">Bill</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 5px solid black;">
                    </td>
                </tr>
                <tr visible="false">
                    <td align="left" style="padding-left: 0px; font-size: 18px; font-weight: bold">
                        <label>
                            Sales Type:
                        </label>
                        <asp:Label ID="lblsalestype" runat="server"></asp:Label><br />
                        <asp:Label ID="lblorderno" runat="server" Visible="false"></asp:Label>
                    </td>
                     <td align="center" style="padding-left: 2px">
                        <asp:Label ID="lblbillname" runat="server" Font-Size="20px" Font-Bold="true"  ></asp:Label>:
                        <asp:Label ID="lblbillno" runat="server" Font-Size="20px" Font-Bold="true"   ></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: bold">
                    <td colspan="1" visible="false" align="left" style="font-size: 18px; font-weight: bold">
                        Name:<asp:Label ID="lblcustname" runat="server"></asp:Label>
                        <asp:Label ID="lblMobile" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblgstno" runat="server"  Font-Size="18px" Visible="true" ></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        <asp:Label ID="lbldate" Font-Bold="true" Font-Size="18px"  runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: bold;" >
                    <td align="left" style="padding-left: 5px">
                        <label>
                            B-Code</label>
                        <asp:Label ID="billedby" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 50px">
                        <label>
                            A-Code</label>
                        <asp:Label ID="atender" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblattender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding-left: 0px">
                        <asp:GridView ID="gvPrint" Width="500px" runat="server" Font-Bold="true" AutoGenerateColumns="false"
                            OnRowDataBound="gvPrint_OnRowDataBound" DataKeyNames="cattype,ComboId,billno" RowStyle-Font-Size="18px"
                            Font-Size="large" GridLines="None">
                            <Columns>
                                <%--<asp:BoundField HeaderText="Item" DataField="printitem" HeaderStyle-HorizontalAlign="Center" />--%>
                                <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item / Hsncode" ItemStyle-Font-Size="18px" HeaderStyle-Width="30%"
                                    ItemStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Eval("printite")%>
                                        <div align="left" id="dv<%# Eval("printitem") %>" style="position: relative;">
                                            <asp:GridView runat="server" ID="gvLiaLedger" ShowHeader="false" ShowFooter="false"
                                                AutoGenerateColumns="false" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="emptys" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Size="Small"
                                                        ItemStyle-Font-Bold="false" />
                                                    <asp:BoundField DataField="def" ItemStyle-Font-Size="Small" ItemStyle-Font-Bold="false" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="15%" Visible="false" HeaderText="GST">
                                    <ItemTemplate>
                                        <asp:Label ID="lblgst" runat="server" Text='<%#Eval("gst")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblrate" runat="server" Text='<%#Eval("mrp")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="15%" HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField HeaderText="" DataField="UnitPrice" HeaderStyle-Width="15%" DataFormatString="{0:N2}"
                                    ItemStyle-Width="50px" Visible="true" />--%>
                                <%--<asp:BoundField HeaderText="Qty" DataField=""  DataFormatString="{0:N3}"
                                    ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Right" />--%>
                                <%--<asp:BoundField HeaderText="  Amount" DataField="" ItemStyle-HorizontalAlign="Center"
                                     ItemStyle-Width="74px" DataFormatString="{0:N2}" />--%>
                                <asp:BoundField HeaderText="C%" DataField="sg" Visible="false" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="S%" HeaderStyle-Width="40px" DataField="cg" Visible="false"
                                    ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Left" />
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
                    <td colspan="2" style="font-size: x-large; text-decoration: none; border-bottom: 5px solid black;">
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
                <tr style="" border="1">
                    <td colspan="1" align="left">
                    <div id="divqtyneeded" runat="server" visible="false" >
                        <label style="font-size: 20px">
                            Total Qty :
                        </label>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label><br />
                        </div>
                        <label style="font-size: 20px">
                            Total Item :
                        </label>
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label>
                    </td>
                    
                    <td colspan="1" align="right" style="padding-right: 17px">
                        <label style="font-size: 20px">
                            SubTotal:
                        </label>
                        <asp:Label ID="lblsubttl" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label>
                    </td>
                </tr>
                <tr style="" border="1" id="PCGST" runat="server">
                    <td colspan="1" align="left" style="padding-right: 17px">
                        <label style="font-size: 20px">
                            CGST:
                        </label>
                        <asp:Label ID="lblcgst" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label>
                    </td>
                    <td colspan="1" align="right" style="padding-right: 17px">
                        <label style="font-size: 20px">
                            SGST:
                        </label>
                        <asp:Label ID="lblsgst" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label>
                    </td>
                </tr>
                <tr style="" border="1" id="TAXID" runat="server">
                    <td colspan="2" align="right" style="padding-right: 17px">
                        <label style="font-size: medium">
                            Tax:
                        </label>
                        <asp:Label ID="lblTotalTax" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr style="" border="1" id="SGST1" runat="server">
                    <td colspan="1" align="left" style="padding-right: 17px">
                        <div runat="server" id="divroundoff" visible="false">
                            <label style="font-size: 20px">
                                R.Off:
                            </label>
                            <asp:Label ID="lblRound" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label>
                        </div>
                    </td>
                    <td colspan="1" align="right" style="padding-right: 17px">
                        <label>
                           Total: (<asp:Label ID="lblcurrency" runat="server"></asp:Label>)
                        </label>
                        <asp:Label ID="lblGrand" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr id="iddiscamt" style="" border="1" runat="server" visible="false">
                    <td colspan="2" align="left" style="padding-right: 17px">
                        <label style="font-size: medium">
                            Discount:
                        </label>
                        <asp:Label ID="lbldiscountamt" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr id="Tr1" style="" border="1" runat="server">
                </tr>
                <tr style="font-weight: bold" border="1">
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trCash" runat="server">
                    <td colspan="2" align="right" style="padding-right: 17px">
                        <label>
                            Cash Received
                        </label>
                        <asp:Label ID="lblReceived" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trPaid" runat="server">
                    <td colspan="2" align="right" style="padding-right: 17px">
                        <label>
                            Balance Paid
                        </label>
                        <asp:Label ID="lblBal" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <%-- <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>--%>
                <tr runat="server" id="paydetails" visible="false" style="width: 100%">
                    <td colspan="2">
                        <label style="font-size: 16px; font-weight: bold">
                            Payment Details History:(BOOK NO:
                            <asp:Label ID="lblbookno" runat="server"></asp:Label>)</label>
                        <asp:GridView ID="Gridpaymentdetails" EmptyDataText="No Payment Details" runat="server"
                            Width="100%" AutoGenerateColumns="false" Font-Names="Monospace" RowStyle-Font-Size="20px">
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
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr runat="server" id="staxdetails" visible="true" style="width: 100%">
                    <td colspan="2">
                        <label runat="server" style="font-size: 16px">
                            Tax Split Up Details :</label>
                        <asp:GridView ID="GridTaxvalue" EmptyDataText="No Tax Split Up Details" OnRowDataBound="GridTaxvalue_OnRowDataBound"
                            runat="server" Width="98%" AutoGenerateColumns="false" Font-Names="Monospace"  Font-Bold="true"  HeaderStyle-Font-Size="18px" RowStyle-Font-Size="20px">
                            <Columns>
                                <asp:BoundField HeaderText="Tax %" DataField="taxvalue"  ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="HSN Code" Visible="false" DataField="hsncode" />
                                <asp:BoundField HeaderText="Item Value" DataField="value" ItemStyle-CssClass="text-right"
                                    DataFormatString="{0:###,##0.00}" />
                                <asp:BoundField HeaderText="CGST Value" DataField="CGST" ItemStyle-CssClass="text-right" />
                                <asp:BoundField HeaderText="SGST Value" DataField="SGST" ItemStyle-CssClass="text-right" />
                                <asp:BoundField HeaderText="Tax Amount" DataField="Tax" ItemStyle-CssClass="text-right" />
                                <asp:BoundField HeaderText="Total Value" DataField="Total" ItemStyle-CssClass="text-right" />
                                <%--<asp:BoundField HeaderText="IGST Value" DataField="IGST" />--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr runat="server" id="traddress" visible="false" style="width: 100%">
                    <td colspan="2">
                    <label>Delivery Address : </label><br />
                    <asp:Label ID="lbladdress" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;
                        padding-bottom: 1pc">
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td colspan="2" align="center">
                        <label style="font-size: large">
                            Kindly Refrigerate Our Fresh Cream products</label>
                        <label runat="server" visible="false" style="font-size: x-large">
                            For Instant Cake Orders
                        </label>
                        <label style="font-size: xx-large" id="txtWebSiteName" runat="server">
                        </label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            Customer Care Number
                            <br />
                            <label style="font-size: x-large" runat="server" id="txtCustomerNo">
                            </label>
                            <br />
                            <label style="font-size: x-large" id="txtEmail" runat="server">
                            </label>
                            <%--<br />
                            Bengaluru - 81055 53338
                            <br />
                            Admin Office - 96266 62846
                            <br />--%>
                        </label>
                    </td>
                </tr>
                <tr runat="server" visible="false" id="home">
                    <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For Home Delivery Order 73733 00355</label>
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td colspan="2" align="center">
                        <label style="font-size: x-large" id="txtSocial" runat="server">
                        </label>
                    </td>
                </tr>
                <tr id="Tr2" runat="server" visible="false">
                <td colspan="2" align="center">
                <asp:Label ID="lbltaxexp" runat="server" Font-Bold="true" Text="**INCLUSIVE OF TAX**" Font-Size="15px" ></asp:Label>
                </td>
                </tr>
                <tr runat="server" visible="true">
                    <td colspan="2" align="center">
                        <img width="50px" height="70px" src="../images/Hand.png" style="margin-left: 0px;" />
                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="THANK YOU VISIT AGAIN"
                            Font-Size="15px"></asp:Label>
                        <img width="50px" height="70px" src="../images/Hand.png" style="margin-left: 0px;" />
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
                            For FeedBack/Queries <br/>
				Bengaluru    -  81055 53338 <br/>
				Admin Office -  96266 62846 <br/>
				</label>
                    </td>
                            </tr>
                             <tr runat="server" visible="false" id="home">
                   <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For Home Delivery Order 73733 00355</label></td>
                            </tr>
             <tr>  <td colspan="2" align="center">
                        <label style="font-size: x-large">
                         Facebook/Instagram - BlaackforestCakes   </label>
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
