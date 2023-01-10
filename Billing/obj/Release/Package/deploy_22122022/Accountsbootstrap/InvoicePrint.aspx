<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePrint.aspx.cs" Inherits="Billing.Accountsbootstrap.InvoicePrint" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        P.pagebreakhere
        {
            page-break-before: always;
        }
        .AlignLeft
        {
            text-align: left;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        
        #footer
        {
            font-size: 10px;
            color: Black;
            text-align: center;
        }
        
        
        @media print
        {
        
            #footer
            {
                position: fixed;
                bottom: 0;
            }
            table
            {
                page-break-inside: auto;
            }
            tr
            {
                page-break-inside: avoid;
                page-break-after: auto;
            }
            thead
            {
                display: table-header-group;
            }
            tfoot
            {
                display: table-footer-group;
            }
        }
        
        .top
        {
            vertical-align: top;
        }
        
        .pdleft
        {
            padding-left: 30px;
        }
        
        .pdright
        {
            text-align: right;
        }
        
        #MH
        {
            width: 100%;
            border-collapse: collapse;
            border: 1px solid black;
            font-size: 11.5px;
            font-family: Calibri;
        }
        
        #MH hr
        {
            height: 0;
            border: 0;
            border-top: 1px solid #083972;
        }
        
        #MH tr td
        {
            padding: 5px;
            border-right: 1px solid black;
        }
        #MH tr td:last-child
        {
            border-right: none;
        }
        
        #MH1
        {
            width: 100%;
            border-collapse: collapse;
            border: 1px solid black;
            font-size: 11.5px;
            font-family: Calibri;
        }
        
        #MH1 hr
        {
            height: 0;
            border: 0;
            border-top: 1px solid #083972;
        }
        
        #MH1 tr td
        {
            padding: 5px;
            border-right: 1px solid black;
        }
        #MH1 tr td:last-child
        {
            border-right: none;
        }
        
        #RTbl
        {
            border-collapse: collapse;
        }
        
        /* SPACE CELLS
#RTbl td:not(:last-child) {
  padding-right: 15px;
} */
        
        #RTbl tr:not(:last-child)
        {
            border-bottom: 1px solid black;
        }
    </style>
    <script type="text/javascript">


        function myFunction() {
            var ButtonControl = document.getElementById("btnprint");
            var fist = document.getElementById("btnexit");

            ButtonControl.style.visibility = "hidden";
            btnexit.style.visibility = "hidden";
            window.print();
        }
    </script>
</head>
<body>
    <%--<body>--%>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td align="center" style="font-size: larger; font-weight: bold">
                <asp:Label ID="lblFormName" runat="server" Text="TAX INVOICE"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" id="MH">
        <tr>
            <td style="width: 50%">
                <div id="karthikamart" runat="server" visible="false">
                    <b>
                        <label style="text-align: right; font-size: 22px;">
                            A.KARTHIKA MARTS</label><br />
                    </b>
                    <label>
                        2/232,Malligai cross street,
                    </label>
                    <br />
                    <label>
                        1<sup>st</sup> Floor,Gomathipuram II road ,
                    </label>
                    <br />
                    <label>
                        Madurai- 625020,Tamilnadu,India.
                    </label>
                    <br />
                    <label>
                        GSTIN/UIN :</label>
                    <label>
                        33AIEPA8062G1ZN</label>
                    <br />
                    <label>
                        E-Mail :</label>
                    <label>
                        info@blaackforest.com
                    </label>
                </div>
                <div id="blaackforest" runat="server" visible="true">
                    <label>
                        Vendor Name :
                    </label>
                    <br />
                    <b>
                        <%-- <label style="text-align: right; font-size: 22px;">
                            BLAACKFOREST</label><br />--%>
                        <label style="text-align: right; font-size: 22px;">
                            Blaack Forest</label><br />
                    </b>
                    <label>
                        <%-- No.2/232 Malligai Cross Street--%>
                        12, Lakeview Road, KK Nagar,
                    </label>
                    <br />
                    <label>
                        Madurai - 625020
                    </label>
                    <br />
                    <label>
                        GSTIN/UIN :
                    </label>
                    <label>
                        33AWBPR0957L1ZA</label>
                    <br />
                    <%--<label>
                        CIN :
                    </label>
                    <label>
                        U74999TN2013PTC091007</label>
                    <br />--%>
                    <label>
                        E-Mail :</label>
                    <label>
                        online@blaackforestcakes.com
                    </label>
                    <br />
                    <label>
                        Contact :</label>
                    <label>
                        +91 84899 55500
                    </label>
                </div>
                <hr />
                Buyer Name:
                <br />
                <b>
                    <asp:Label ID="lblCustomerName1" runat="server"></asp:Label></b><br />
                <asp:Label ID="lblAddr1" runat="server"></asp:Label><br />
                <asp:Label ID="lblAddress1" runat="server"></asp:Label><br />
                <%--<asp:Label ID="lblCity1" runat="server"></asp:Label><br />--%>
                <asp:Label ID="lblCountry1" runat="server"></asp:Label><br />
                <asp:Label ID="lblEMail1" runat="server"></asp:Label><br />
                State Name :
                <asp:Label ID="lblState1" runat="server"></asp:Label><br />
                Place of Supply :
                <asp:Label ID="lblPlaceofSupply" runat="server"></asp:Label><br />
                <label>
                    GSTIN/UIN :</label><asp:Label ID="lblcustgstin" runat="server"></asp:Label><br />
            </td>
            <td style="width: 50%">
                <table width="100%" id="RTbl">
                    <tr>
                        <td width="50%">
                            <b>
                                <label>
                                    Invoice No :
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblInvoiceNo" Style="text-align: left;" runat="server"></asp:Label>
                        </td>
                        <td width="50%">
                            <b>
                                <label>
                                    Dated
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblInvoiceDate" Style="text-align: right" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <%--<td>
                            <b>
                                <label>
                                    Delivery Note
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="Label27" runat="server"></asp:Label>
                        </td>--%>
                        <td>
                            <b>
                                <label>
                                    Supplier's Ref
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblsupplierref" runat="server" Text="BF"></asp:Label>
                        </td>
                        <td>
                            <b>
                                <label>
                                    Mode/Terms of Payment
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbltermspayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%-- <tr>
                       
                        <td>
                            <b>
                                <label>
                                    Other Reference(s)
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblotherreference" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <b>
                                <label>
                                    Buyer Order No.
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblbuyerorderno" runat="server"></asp:Label>
                        </td>
                        <td>
                            <b>
                                <label>
                                    Dated
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lblOrderdate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td>
                            <b>
                                <label>
                                    Despatch Document No.
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbldespatchdocument" runat="server"></asp:Label>
                        </td>
                        <td>
                            <b>
                                <label>
                                    Delivery Note Date
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbldeliverynotedate" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <b>
                                <label>
                                    Despatched Through
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbldespatchthrogh" runat="server" Text="By Road"></asp:Label>
                        </td>
                        <td>
                            <b>
                                <label>
                                    Destination
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbldestination" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b>
                                <label>
                                    Terms Of Delivery
                                </label>
                            </b>
                            <br />
                            <asp:Label ID="lbltermsofdelivery" runat="server" Text="NA"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div>
        <table width="100%" height="250px" border="0" class="style1">
            <tr>
                <td valign="top" align="left" style="width: 50%">
                    <asp:GridView runat="server" BorderWidth="1" ID="gvProduct" GridLines="Vertical"
                        OnRowDataBound="gvProduct_OnRowDataBound" AlternatingRowStyle-CssClass="even"
                        AutoGenerateColumns="false" ShowHeader="true" ShowFooter="true" AllowPrintPaging="true"
                        Width="100%">
                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                        <FooterStyle BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" HorizontalAlign="Right" />
                        <%--   <asp:GridView ID="gvProduct" Visible="true" CssClass="mynewGridStyle" ShowHeaderWhenEmpty="true" GridLines="Vertical"
            Width="100%" EmptyDataText="No Records Found" runat="server" AutoGenerateColumns="false"
            ShowFooter="false" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="White">
            <HeaderStyle CssClass="gradient" BorderStyle="Solid" />--%>
                        <%--<RowStyle Height="2px" />--%>
                        <Columns>
                            <asp:BoundField HeaderText="S.No" DataField="Sno" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="2%"  />
                            <asp:TemplateField HeaderText="Description of Goods" ItemStyle-HorizontalAlign="left"
                                ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Product") %>' Style="text-align: left;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HSN/SAC" ItemStyle-HorizontalAlign="left" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("HSNCode") %>' Style="text-align: Center;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GST Rate" ItemStyle-HorizontalAlign="left" Visible="false"
                                ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:Label ID="lblGST" runat="server" Text='<%#Eval("GST") %>' Style="text-align: Center;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>' Style="text-align: Center;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate(INR)" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Rate") %>' Style="text-align: Center;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Per" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:Label ID="lblPer" runat="server" Text='<%#Eval("Per") %>' Style="text-align: Center;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount(INR)" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>' Style="text-align: Center;"></asp:Label>
                                    <asp:Label ID="lblTot" runat="server" Text='<%#Eval("TotAmount") %>' Style="text-align: Center;"
                                        Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" id="MH1">
            <tr>
                <td style="width: 50%">
                    Amount Chargeable (in words)<br />
                    <asp:Label ID="lblAmountinwords" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td style="width: 50%; text-align: right">
                    E. & O.E
                </td>
            </tr>
        </table>
    </div>
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
                        <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>' Style="text-align: Center;"></asp:Label>
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
            </Columns>
        </asp:GridView>
    </div>
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
    <center>
        <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction()" />
        <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" />
    </center>
    </form>
</body>
</html>
