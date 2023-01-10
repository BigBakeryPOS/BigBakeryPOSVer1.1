<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintSalesVat.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PrintSalesVat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript">
        var myWindow;

        function window.print() {
            myWindow = window.open("", "", "width=100, height=100");
        }

        function resizeWin() {
            myWindow.resizeTo(250, 250);
            myWindow.focus();
        }
    </script>
    <script language="javascript" type="text/javascript">
        window.print();
    </script>
</head>
<body onload=" window.print()">
    <form id="form1" runat="server">
    <div>
        <div>


            <table width="750px">
                <tr>

                 <td></td>
                    <td align="center">
                       
                        <asp:Label ID="lblpvtltd" runat="server" Text="POTHYS Pvt Ltd" Style="font-weight: bold;
                            font-size: x-large" Visible="false"></asp:Label><br />
                        <asp:Label Style="font-weight: bold; font-size: larger" ID="lblstore" runat="server"></asp:Label><br />
                        <asp:Label Style="font-size: small;" ID="lblAddres" runat="server"></asp:Label><br />
                        GSTIN:
                        <asp:Label ID="lbltin" runat="server"></asp:Label><br />
                         <label style="font-weight: bold; font-size: larger">
                            Sales and Vat Details</label><br />
                         Date: <asp:Label ID="lblcanDate" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>

                     <td></td>
                </tr>
                <tr id="Oldorder" runat="server" visible="false">
                    <td>
                        <label>
                            *****Cancelled Order*****</label>
                    </td>
                </tr>
                <tr id="order" runat="server" visible="false">
                    <td>
                        <label>
                            cancelled order No:</label>
                        <asp:Label ID="lblcancelno" runat="server" Font-Size="Smaller"></asp:Label>
                        <label>
                            Date:</label>
                       
                    </td>
                </tr>
                <tr id="cust" runat="server" visible="false">
                    <td>
                        <label>
                            Name</label>
                        <asp:Label ID="lblcanname" runat="server" Font-Size="Smaller"></asp:Label>
                        <asp:Label ID="lblcanAddress" runat="server" Font-Size="Smaller"></asp:Label>-
                        <asp:Label ID="lblcanPhoneNo" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="grid" runat="server" visible="false">
                    <td align="center">
                        <asp:GridView ID="gvPrintcan" runat="server" Width="265px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:N1}" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="S" DataField="gs" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="C" DataField="gs" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="Tr3" runat="server" visible="false">
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Sub.Total</label>
                        <asp:Label ID="lblsubtotalls" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="Tr121" runat="server" visible="false">
                    <td align="right">
                        <label>
                            SGST</label>
                        <asp:Label ID="lblsgg" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="Tr2" runat="server" visible="false">
                    <td align="right">
                        <label>
                            CGST</label>
                        <asp:Label ID="lblcgg" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="toal" runat="server" visible="false">
                    <td align="right">
                        <label>
                            Total</label>
                        <asp:Label ID="lblcanTotalAmount" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="advance" runat="server" visible="false">
                    <td align="right">
                        <label>
                            Advance</label>
                        <asp:Label ID="lblcanAdvance" runat="server" Text="400" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="balance" runat="server" visible="false">
                    <td align="right">
                        <label>
                            Balance:</label>
                        <asp:Label ID="lblcanBalanceAmt" runat="server" Text="1100" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="deliverydate" runat="server" visible="false">
                    <td>
                        <label>
                            Delivery Date:</label>
                        <asp:Label ID="lblcanDeliveryDate" runat="server" Font-Size="Smaller"></asp:Label>-
                        <asp:Label ID="lblcanTime" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="oldpaymode1" runat="server" visible="false">
                    <td>
                        <label>
                            Paymode:</label>
                        <asp:Label ID="oldpaymode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="ordertakenby" runat="server" visible="false">
                    <td>
                        <label>
                            Order Taken By:-</label>
                        <asp:Label ID="lblcanOrderTakenBy" runat="server" Text="Chandran" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr id="neworder" runat="server" visible="false">
                    <td>
                        <label>
                            *****New Order*****</label>
                    </td>
                </tr>
               
               
                <tr>
                <td></td>
                    <%--<td style="font-size: large; text-decoration: none; border-bottom: 3px solid black;">
                    </td>--%>
                </tr>
                <tr>
                    <td align="center" style="font-weight: bold; font-size: larger">
                        <asp:GridView ID="gvPrint" runat="server" Width="265px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:N1}" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="S" DataField="gs" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="C" DataField="gs" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <table border="2" width="100%" style="margin-top: 20px">
                    <tr>
                        <td align="center">
                        </td>
                        <td align="center">
                          <%--  <label>
                                Total Bill Amount</label>--%>
                                 <asp:Label ID="Label4" runat="server" Font-Size="Large" Font-Bold="true">Bill Amount</asp:Label>
                        </td>
                        <td align="center">
                          <%--  <label>
                                Total Vat Amount</label>--%>
                                  <asp:Label ID="Label5" runat="server" Font-Size="Large" Font-Bold="true">Vat Amount</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                          <%--  <label>
                                0%</label>--%>
                                 <asp:Label ID="Label1" runat="server" Font-Size="X-Large">0%</asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbltotalamtzero" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblvatamtzero" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                           <%-- <label>
                                5%</label>--%>
                                   <asp:Label ID="Label2" runat="server" Font-Size="X-Large">5%</asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbltotalamtfive" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblvatamtfive" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                           <%-- <label>
                                18%</label>--%>
                                 <asp:Label ID="Label3" runat="server" Font-Size="X-Large">18%</asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbltotalamteighteen" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblvatamteighteen" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                    <td colspan="3" style="text-align:right">

                    
                                        <div id="ididisc" runat="server" visible="true">
                                         <label>DiscountAmount:</label><br />
                                          <asp:Label ID="lbldiscsmt" runat="server" Font-Size="XX-Large"></asp:Label>
                                        </div>

                     <label>GrandTotal:</label><br />
                                          <asp:Label ID="lblfinaltotal" runat="server" Font-Size="XX-Large"></asp:Label>
                    </td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>

        </div>
    </div>
    </form>
</body>
</html>
