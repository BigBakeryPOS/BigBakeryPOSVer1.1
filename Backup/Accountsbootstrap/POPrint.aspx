<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POPrint.aspx.cs" Inherits="Billing.POPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PO Print</title>
    <link href="../Styles/style1.css" rel="stylesheet" />
    <script type="text/javascript">
        function myFunction() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="1">
        <tr>
            <td align="center">
                BLAACKFOREST BAKERY<br />
                2/232,MALLIGAI CROSS STREET,<br />
                GOMATHIPURAM 2ND MAIN,<br />
                MADURAI 625020 TAMILNADU,<br />
                Ph : +91 452 4393091/ +91 9842279837
                <br />
                E-mail id: info@blaackforest.com Web : www.blaackforest.com<br />
                TIN NO : 123456
            </td>
        </tr>
        <tr>
            <td align="center" class="style1">
                <h2>
                    <asp:Label ID="lblpotype" runat="server"></asp:Label><br />
                </h2>
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td align="left">
                To Address :
                <h2>
                    <b>
                        <asp:Label ID="lblcompanyname" runat="server"></asp:Label></b></h2>
                <asp:Label ID="lbltoaddress" runat="server"></asp:Label><br />
                <asp:Label ID="lblarea" runat="server"></asp:Label><br />
                <asp:Label ID="lblcity" runat="server"></asp:Label>
                <asp:Label ID="lblpincode" runat="server"></asp:Label><br />
                <asp:Label ID="lbltinno" runat="server"></asp:Label>
            </td>
            <td align="left">
                DC No:
                <asp:Label ID="lblpono" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                DC Date :
                <asp:Label ID="lblpodate" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                Paymode :
                <asp:Label ID="lblpaymode" runat="server"></asp:Label>
                <div id="type" runat="server" visible="false">
                    Purchase Type :
                    <asp:Label ID="lblpurchasetype" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td align="center">
                <asp:GridView ID="gridprint" runat="server" CssClass="mGrid" Width="100%" AllowSorting="true"
                    ShowFooter="true" EmptyDataText="No Records Found" AutoGenerateColumns="false"
                    OnRowDataBound="gridview_OnRowDataBound">
                    <HeaderStyle BackColor="#3366FF" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        NextPageText="Next" PreviousPageText="Previous" />
                    <Columns>
                        <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                        <asp:BoundField HeaderText="Units" DataField="UOM" />
                        <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                        <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}' />
                        <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' />
                        <asp:BoundField HeaderText="Narrations" DataField="Narrations" />
                    </Columns>
                    <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td align="left">
                <b>Terms & Conditions :</b><br />
                Delivery Schedule - Within 10 Days<br />
                Payment of Terms - 60 Days<br />
            </td>
            <td align="right">
                Sub Total :
                <asp:Label ID="lblsubtotal" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                CGST :
                <asp:Label ID="lblcgst" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                SGST :
                <asp:Label ID="lblsgst" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                IGST :
                <asp:Label ID="lbligst" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label><br />
                Total Amount :
                <asp:Label ID="lbltotalamt" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
    </table>
    <table border="1">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            Kindly acknowledge the receipt of this order and confirm delivery. Our order number
                            must appear on all packing slips, delivery challans and invoice. If the goods suffers
                            Excise Duty the duplicate invoice copy / Excise Duty paid details should be provide
                            along with the material to avail CENVAT, Excise Duty invoice to be raised only to
                            our factory address to avail CENVAT.
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <h2>
                                for<b> BLAACKFOREST BAKERY</b></h2>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td valign="bottom" style="width: 400px; text-align: center">
                            Prepared
                        </td>
                        <td valign="bottom" style="width: 400px; text-align: center">
                            Checked
                        </td>
                        <td valign="bottom" style="width: 400px; text-align: center">
                            Authorised Signatory
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td align="center">
                <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction()" />
                <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
