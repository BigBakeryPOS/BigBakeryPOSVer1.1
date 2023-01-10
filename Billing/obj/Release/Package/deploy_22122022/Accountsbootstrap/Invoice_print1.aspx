<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice_print1.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Invoice_print1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invoice Print</title>
    <link href="../Styles/style1.css" rel="stylesheet" />
    <script type="text/javascript">


        function myFunction() {
            var ButtonControl = document.getElementById("btnprint");
            var fist = document.getElementById("btnexit");

            ButtonControl.style.visibility = "hidden";
            btnexit.style.visibility = "hidden";
            window.print();
        }
    </script>
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            font-family: Verdana;
        }
        .style2
        {
            height: 120px;
        }
        .myleft
        {
            border-collapse: collapse;
            width: 85%;
            margin-left: 0px;
            border: 1px solid gray;
            overflow: hidden;
        }
        .myleft tr th
        {
            padding: 8px;
            color: Black;
            border: 1px solid gray;
            font-family: Arial;
            font-size: 10pt;
            text-align: center;
        }
        .myleft td
        {
            border: 1px solid gray;
            padding: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <table style="border-spacing: 1px; border-collapse: collapse; outline: black solid 1px"
            width="100%" height="100%" class="style1">
            <tr>
                <td style="height: 1px">
                    <table width="100%" border="1" style="border: none; border-collapse: collapse" class="style1">
                        <tr>
                            <td align="center">
                                <label style="font-size: large; font-weight: bold">
                                    <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label></label>
                                <b>
                                    <label>
                                        DELIVERY NOTE</label></b><br />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="1" style="border: none; height: 10px">
                        <tr style="height: 10px">
                            <td align="left" class="style2" style="width: 40%; height: 10px" rowspan="3" colspan="3">
                                <b>BLAACK FOREST 2020-21 </b>
                                <br />
                                1st Floor, 2/232 Malligai Cross Street,<br />
                                Gomathipuram II Road,<br />
                                Madurai - 625020<br />
                                B.O. Plot No : 1-15 Melur Main Road,<br />
                                Opposite to Reliance Market<br />
                                Uthangudi, Madurai - 620107<br />
                                Mobile No : 9943363525<br />
                                GSTIN/UIN: 33AWBPR0957L1ZA<br />
                                State Name : Tamil Nadu, Code : 33<br />
                                E-Mail : blaackforestmadurai @gmail.com<br />
                            </td>
                            <td align="left" style="width: 30%; height: 5px; vertical-align: top">
                                Delivery Note No. &nbsp e-Way BillNo.<br />
                                <b>
                                    <asp:Label ID="lblDeliveryNoteNo" runat="server"></asp:Label></b>
                            </td>
                            <td style="width: 30%; height: 5px; vertical-align: top">
                                Dated<br />
                                <b>
                                    <asp:Label ID="lblDated" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 30%; height: 10px; vertical-align: top">
                                Supplier's Ref.
                            </td>
                            <td style="width: 20%; height: 10px; vertical-align: top">
                                Mode/Terms of Payment
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 30%; height: 10px; vertical-align: top">
                                Buyer Order No
                            </td>
                            <td style="width: 30%; height: 10px; vertical-align: top">
                                Dated
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td align="left" valign="top" style="width: 40%; height: 10px" colspan="3" rowspan="2">
                                <label>
                                    Buyer :</label>
                                <b>
                                    <asp:Label ID="lblbuyer" runat="server"></asp:Label></b>
                                <br />
                                <asp:Label ID="lbladdress" runat="server"></asp:Label><br />
                                <asp:Label ID="lblcity" runat="server"></asp:Label><br />
                                <asp:Label ID="lblstate" runat="server"></asp:Label><br />
                                GST IN/UIN:<asp:Label ID="lblgst" runat="server"></asp:Label>
                                <%-- State Name:<asp:Label ID="lblstate" runat="server"></asp:Label>,Code:<asp:Label ID="lblcode"
                                    runat="server"></asp:Label><br />--%>
                            </td>
                            <td align="left" style="width: 30%; height: 10px; vertical-align: top">
                                Despatched Through <b>
                                    <asp:Label ID="lblDespatchedThrough" runat="server"></asp:Label></b>
                            </td>
                            <td align="left" style="width: 30%; height: 10px; vertical-align: top">
                                Destination <b>
                                    <asp:Label ID="lblDestination" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td align="left" valign="top" class="style2" style="height: 10px" colspan="2">
                                Terms of Delivery
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="250px" border="0" class="style1">
                        <tr>
                            <td valign="top" align="left" style="width: 50%">
                                <asp:GridView runat="server" BorderWidth="1" ID="GVPrint" GridLines="Vertical" AlternatingRowStyle-CssClass="even"
                                    OnRowDataBound="GVPrint_OnRowDataBound" AutoGenerateColumns="false" ShowHeader="true"
                                    ShowFooter="true" PrintPageSize="30" AllowPrintPaging="true" Width="100%" Style="font-family: 'Trebuchet MS';
                                    font-size: 17px;">
                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="SNo" HeaderText="SNo" HeaderStyle-Width="1%" />
                                        <asp:BoundField DataField="ItemName" HeaderText="Description of Goods" HeaderStyle-Width="35%"
                                            FooterStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="HSNCode" HeaderText="HSN/SAC" HeaderStyle-Width="10%" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="10%" />
                                        <asp:BoundField DataField="Rate" HeaderText="Rate" HeaderStyle-Width="10%" />
                                        <asp:BoundField DataField="Per" HeaderText="per" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="10%" DataFormatString="{0:0.00}"
                                            ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                        <%--<asp:BoundField DataField="Per" HeaderText="Per" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />--%>
                                        <%--<asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="10%" DataFormatString="{0:f2}"
                                            ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="1" style="border: none">
                        <tr>
                            <td style="width: 100%;">
                                Amount (in words)<br />
                                <b>
                                    <asp:Label ID="lblAmountinwords" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:GridView runat="server" BorderWidth="1" ID="gvGST" GridLines="Vertical" OnRowDataBound="gvGST_OnRowDataBound"
                            AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false" ShowHeader="true"
                            ShowFooter="true" AllowPrintPaging="true" Width="100%">
                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                            <FooterStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" HorizontalAlign="Right" />
                            <%--    <asp:GridView ID="gvGST" Visible="true" CssClass="mynewGridStyle" ShowHeaderWhenEmpty="true"
            Width="100%" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="false"
            ShowFooter="false" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="White">
            <HeaderStyle CssClass="gradient" />--%>
                            <Columns>
                                <asp:TemplateField HeaderText="HSN/SAC" ItemStyle-HorizontalAlign="left" ItemStyle-Width="35%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("HSNCode") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Taxable Value(INR)" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%#Eval("TaxAmount") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CGST Rate" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCGSTRate" runat="server" Text='<%#Eval("CGSTRate") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CGST Amount(INR)" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCGSTAmount" runat="server" Text='<%#Eval("CGSTAmount") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SGST Rate" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSGSTRate" runat="server" Text='<%#Eval("SGSTRate") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SGST Amount(INR)" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSGSTAmount" runat="server" Text='<%#Eval("SGSTAmount") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Tax Amount(INR)" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tax" ItemStyle-HorizontalAlign="right" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltax" runat="server" Text='<%#Eval("Tax") %>' Style="text-align: Center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <%--                    <table width="100%" border="0" style="border: none">
                        <tr>
                         <%--   <td style="width: 100%;">
                               <%-- Tax Amount (in words)<br />
                                <b>
                                    <asp:Label ID="lblTaxAmountinwords" runat="server"></asp:Label></b>
                                <br />
                                <br />
                                <br />
                                <br />
                                Company's PAN : <b>AWBPR0957L</b><br />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="1" style="border: none">
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                Recd in Good Conditions:<br />
                            </td>
                            <td style="width: 50%; vertical-align: top; text-align: right">
                                for <b>BLAACK FOREST 2020-21</b><br />
                                <br />
                                <br />
                                Authorised Signature
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
        </table>
        <div style="border: 1px solid black">
            <table width="100%" id="Table1">
                <tr>
                    <td style="width: 100%">
                        Tax Amount (in words)<br />
                        <asp:Label ID="lblTaxAmountinwords" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table width="100%">
                <tr>
                    <td style="width: 50%">
                        Company's PAN &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <b>AWBPR0957L</b><br />
                        Declaration We declare that this invoice shows the actual price of the goods described
                        and that all particulars are true and correct
                    </td>
                    <td style="width: 50%; border: 1px solid black; text-align: right">
                        For&nbsp&nbsp <b>Blaack Forest</b> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<br />
                        <br />
                        <br />
                        <br />
                        Authorized Signatory&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    </td>
                </tr>
            </table>
        </div>
        <table width="595px" class="style1">
            <tr>
                <td align="center">
                    <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction()" />
                    <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_OnClick" />
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
