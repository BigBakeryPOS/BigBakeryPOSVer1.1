<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice_print.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Invoice_print" %>

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
                    <table width="100%" border="1" style="border-spacing: 1px; border-collapse: collapse"
                        class="style1">
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
                            <td align="left" style="width: 30%; height: 10px">
                            </td>
                            <td style="width: 20%; height: 10px; vertical-align: top">
                                Mode/Terms of Payment
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 30%; height: 10px; vertical-align: top">
                                Supplier's Ref.
                            </td>
                            <td style="width: 30%; height: 10px; vertical-align: top">
                                Other Reference(s)<br />
                                <%--<b>INTER UNIT TRANSFER</b>--%>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td align="left" valign="top" class="style2" style="width: 40%; height: 10px" rowspan="4"
                                colspan="3">
                                <label>
                                    Buyer :</label>
                                <br />
                                <b><asp:Label ID="lblbuyer" runat="server" ></asp:Label></b>
                                <br />
                                <asp:Label ID="lbladdress" runat="server" ></asp:Label><br />
                                <asp:Label ID="lblcity" runat="server" ></asp:Label><br />
                                State Name:<asp:Label ID="lblstate" runat="server" ></asp:Label>,Code:<asp:Label ID="lblcode" runat="server" ></asp:Label><br />
                            </td>
                            <td style="width: 30%; height: 10px">
                                Buyer Order No
                                <br />
                                <br />
                            </td>
                            <td style="width: 30%; height: 10px; vertical-align: top">
                                Dated
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%; height: 10px">
                                Despathch Document No.
                                <br />
                                <br />
                            </td>
                            <td style="width: 30%; height: 10px">
                                <br />
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td align="left" class="style2" style="width: 30%; height: 10px; vertical-align: top">
                                Despatched Through<br />
                                <br />
                                <b>
                                    <asp:Label ID="lblDespatchedThrough" runat="server"></asp:Label></b>
                            </td>
                            <td align="left" style="width: 30%; height: 10px">
                                Destination<br />
                                <b>
                                    <asp:Label ID="lblDestination" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                         <tr style="height: 10px">
                            <td align="left" class="style2" style="width: 30%; height: 10px; vertical-align: top">
                                Bill of Lading/LR-RR No.<br />
                                <br />
                                <b>
                                    <asp:Label ID="Label1" runat="server"></asp:Label></b>
                            </td>
                            <td align="left" style="width: 30%; height: 10px">
                                Motor Vehicle No<br />
                                <b>
                                    <asp:Label ID="lblvehicleno" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td style="width: 60%; height: 10px; vertical-align: top" colspan="2">
                                Terms of Delivery
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
                                        <asp:BoundField DataField="nos" HeaderText="UOM" HeaderStyle-Width="10%" 
                                            ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="WeightorKg" HeaderText="Quantity" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                        
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
                    <table width="100%" height="50px" border="0" class="style1">
                        <tr>
                            <td valign="top" align="left" style="width: 50%">
                                <asp:GridView runat="server" BorderWidth="1" ID="GVPrintGST" GridLines="Both" OnRowDataBound="GVPrintGST_OnRowDataBound"
                                    AlternatingRowStyle-CssClass="even" AutoGenerateColumns="false" ShowHeader="true"
                                    ShowFooter="true" PrintPageSize="30" AllowPrintPaging="true" Width="100%" Style="font-family: 'Trebuchet MS';
                                    font-size: 17px;">
                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SLNo" HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="hsncode" HeaderText="HSN/SAC" HeaderStyle-Width="10%"
                                            FooterStyle-HorizontalAlign="Right" />
                                      <%--  <asp:BoundField DataField="TaxableValue" HeaderText="TaxableValue" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="CentralRate" HeaderText="CentralRate" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="CentralAmount" HeaderText="CentralAmount" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="StateRate" HeaderText="StateRate" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="StateAmount" HeaderText="StateAmount" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />--%>
                                        <asp:BoundField DataField="netamount" HeaderText="Taxable Value" HeaderStyle-Width="10%"
                                            DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" border="0" style="border: none">
                        <tr>
                            <td style="width: 100%;">
                                Tax Amount (in words)<br />
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
                    </table>
                </td>
            </tr>
        </table>
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
