<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashReceipt.aspx.cs" Inherits="Billing.Accountsbootstrap.CashReceipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Receipt Print</title>
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
            height: 20px;
        }
        .style2
        {
            height: 20px;
        }
        .dotted-line
        {
            text-decoration: none;
            top: 10px;
        }
        .dotted-line:after
        {
            letter-spacing: 6px;
            font-size: 30px;
            color: #9cbfdb;
            display: inline-block;
            vertical-align: 3px;
            padding-left: 10px;
        }
    </style>
    <link href="../bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../bower_components/metisMenu/dist/metisMenu.min.css" rel="stylesheet" />
    <!-- Timeline CSS -->
    <link href="../dist/css/timeline.css" rel="stylesheet" />
    <link href="../styles/style1.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />
    <!-- Morris Charts CSS -->
    <link href="../bower_components/morrisjs/morris.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="Styles/date.css" />
    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <table>
            <tr>
                <td colspan="3">
                    <table width="100%" style="border: solid 1px">
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Label ID="lblname" runat="server" Text="Receipt Print" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table border="1" width="100%">
                        <tr>
                            <td width="2%">
                            </td>
                            <td width="54%" valign="top" style="border-right: solid 1px">
                                Receipt No :
                                <asp:Label ID="lblBillNo" runat="server"></asp:Label><br />
                                Receipt Date :
                                <asp:Label ID="lblBillDate" runat="server"></asp:Label><br />
                                PayMode :
                                <asp:Label ID="lblPayMode" runat="server"></asp:Label><br />
                            
                                <asp:Label ID="lblbankname" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td width="2%">
                            </td>
                            <td width="38%" valign="top">
                                Customer Name :
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label><br />
                                PhoneNo :
                                <asp:Label ID="lblCustomerPhoneNo" runat="server"></asp:Label><br />
                             
                                <asp:Label ID="lblchequeno" runat="server" Style="text-align: center" Visible="false"></asp:Label><br />
                                <asp:Label ID="lbldcno" runat="server" Visible="true"></asp:Label>
                                <asp:Label ID="lblCustomerAddress" runat="server" Style="text-align: center" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div runat="server" id="divgv">
                        <asp:GridView runat="server" ID="gridprint" AutoGenerateColumns="false" ShowFooter="true"
                            ShowHeader="true" Width="100%" OnRowDataBound="gridprint_RowDataBound">
                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="BillNo" DataField="BillNo" />
                                <asp:BoundField HeaderText="BillDate" DataField="ReceiptDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Receipt Amount" DataField="Amount" DataFormatString="{0:f2}"
                                    ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Entry By" DataField="Narration" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table style="width: 100%; border: solid 1px">
                        <tr style="border: solid 1px" runat="server" visible="false">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                Total Items:
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lbltotalitems" Visible="true"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: solid 1px" runat="server" visible="false">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                Sub.Total:
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lblSubtotal" Visible="true"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: solid 1px" runat="server" visible="false" id="Distr">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                Tax Amount:
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lblTaxamount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: solid 1px" runat="server" visible="false" id="discper">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                Discount(%):
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lbldiscper" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: solid 1px" runat="server" visible="false" id="discamt">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                Discount(Rs.):
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lbldiscamt" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: solid 1px">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                GrandTotal:
                            </td>
                            <td style="border-bottom: solid 1px; text-align: right; width: 15%">
                                <asp:Label Font-Size="16px" Style="text-align: right" ID="lblgrandtotal" Visible="true"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" style="border: solid 1px">
                        <tr>
                            <td width="35%" valign="bottom" style="border-right: solid 1px; border-bottom: solid 1px;
                                font-size: 14px">
                                <asp:Label ID="lbldates" runat="server" Visible="false"></asp:Label><br />
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="center" id="image1" width="35%" valign="bottom" runat="server" visible="false"
                                style="border-right: solid 1px; font-size: 14px">
                                <asp:Image ID="m1" runat="server" Width="50%" Height="2pc" ImageUrl="../Images/m1.png"
                                    Style="background-position: bottom" />
                                <br />
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="center" id="image2" width="35%" valign="bottom" runat="server" visible="false"
                                style="border-right: solid 1px; font-size: 14px">
                                <asp:Image ID="m2" runat="server" Width="50%" Height="3pc" ImageUrl="../Images/m2.png"
                                    Style="background-position: bottom" />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table width="595px" class="style1">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction()" />
                                <asp:Button ID="btnexit" runat="server" Text="Exit" PostBackUrl="~/Accountsbootstrap/CashReceipts.aspx" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
