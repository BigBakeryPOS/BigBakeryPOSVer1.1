<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Billing.Accountsbootstrap.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <table width="300px">
                <tr>
                    <td align="center">
                        <label style="font-weight: bold; font-size: larger">
                            INVOICE</label><br />
                        <asp:Label ID="lblpvtltd" runat="server" Text="POTHYS Pvt Ltd" Style="font-weight: bold;
                            font-size: x-large" Visible="false"></asp:Label><br />
                        <asp:Label Style="font-weight: bold; font-size: larger" ID="lblstore" runat="server"></asp:Label><br />
                        <asp:Label Style="font-size: small;" ID="lblAddres" runat="server"></asp:Label><br />
                        GSTIN:
                        <asp:Label ID="lbltin" runat="server"></asp:Label><br />
                         <div  id="idFranchisee" runat="server" visible="false">       
                         <asp:Label ID="Label3" runat="server" Style="font-size: x-large">(Franchisee: <asp:Label ID="lblfranchise" runat="server" ></asp:Label>)</asp:Label>
                         <%--<asp:Label ID="Label2" runat="server" Style="font-size: large">Keestu Mithai</asp:Label>--%>
                        <br />
                        </div>
                    </td>
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
                        <asp:Label ID="lblcanDate" runat="server" Font-Size="Smaller"></asp:Label>
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
                <tr id="Tr1" runat="server" visible="false">
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
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            OrderNo:-</label>
                        <asp:Label ID="lblOrderNo" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            BookNo:-</label>
                        <asp:Label ID="lblBookno" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            Date</label>
                        <asp:Label ID="lblDate" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            Name :</label>
                        <asp:Label ID="lblname" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                        <asp:Label ID="lblAddress" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>-
                        <asp:Label ID="lblPhoneNo" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: large; text-decoration: none; border-bottom: 3px solid black;">
                    </td>
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
                                <asp:BoundField HeaderText="GST %" DataField="gs"  ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Center" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Sub.Total</label>
                        <asp:Label ID="lblsubtotal" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            SGST</label>
                        <asp:Label ID="lblsg" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            CGST</label>
                        <asp:Label ID="lblcg" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                 <tr id="discc" runat="server" visible="false" >
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Disc.Amount</label>
                        <asp:Label ID="lbldisc" runat="server" Text="0" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Total</label>
                        <asp:Label ID="lblTotalAmount" runat="server" Text="1500" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Advance</label>
                        <asp:Label ID="lblAdvance" runat="server" Text="400" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-weight: bold; font-size: larger">
                        <label>
                            Balance:</label>
                        <asp:Label ID="lblBalanceAmt" runat="server" Text="1100" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: large; text-decoration: none; border-bottom: 3px solid black;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Message :
                        </label>
                        <asp:Label ID="lblMessage" runat="server" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td>
                        <label>
                            Paymode:</label>
                        <asp:Label ID="paymode1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; font-size: larger">
                        <label>
                            Delivery Date:</label>
                        <asp:Label ID="lblDeliveryDate" runat="server" Font-Size="Smaller"></asp:Label>-
                        <asp:Label ID="lblTime" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; font-size: medium">
                        <label>
                            Delivery Place:</label>
                        <asp:Label ID="lblPlace" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Order Taken By:-</label>
                        <asp:Label ID="lblOrderTakenBy" runat="server" Text="Chandran" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Payment Details History</label>
                        <asp:GridView ID="Gridpaymentdetails" EmptyDataText="No Payment Details" runat="server"
                            Width="100%" AutoGenerateColumns="false" Font-Names="Calibri">
                            <Columns>
                                <asp:BoundField DataField="Billdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Payment Date" />
                                <asp:BoundField DataField="Amount" DataFormatString="{0:###,##0.00}" HeaderText="Paid Amount" />
                                <asp:BoundField DataField="Type" HeaderText="Paid Type" />
                                <asp:BoundField DataField="mod" HeaderText="Pay Mode" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr runat="server" visible="false" >
                    <td align="center" style="font-size: small">
                        <label>
                            Kindly Refrigerate Our Fresh Cream products</label><br />
                        <label>
                            HAPPENING PLACE</label>
                    </td>
                </tr>
                 <tr id="Tr4" runat="server" visible="true">
                    <td colspan="2" align="center">
                        <img width="50px"  height="70px" src="../images/Hand.png" style="margin-left: 0px; display:none;" />
                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="THANK YOU VISIT AGAIN"
                            Font-Size="15px"></asp:Label>
                        <img width="50px"  height="70px" src="../images/Hand.png" style="margin-left: 0px; display:none;" />
                    </td>
                </tr>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
