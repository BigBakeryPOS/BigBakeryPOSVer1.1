<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WholeSalesQtyPrint.aspx.cs"
    Inherits="Billing.Accountsbootstrap.WholeSalesQtyPrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sales Print</title>
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
    <style>
        .centerHeaderText th
        {
            text-align: center;
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
        <table border="1" width="595px" class="style1">
            <tr style="font-family: Courier New; font-weight: bolder;">
                <tr style="font-family: Courier New; font-weight: bold;" align="center">
                    <td colspan="2" align="center">
                        <asp:Label ID="l2" runat="server" Style="font-weight: bolder; font-size: x-large"
                            Visible="true">DELIVERY CHALLEN</asp:Label>
                        <br />
                    </td>
                </tr>
                <td colspan="2" align="center" style="font-size: x-large;">
                    <asp:Label ID="lblstore1" runat="server" Style="font-weight: bold; font-size: 36px"
                        Visible="true"></asp:Label>
                    <div id="idFranchisee" runat="server" visible="false">
                        <asp:Label ID="Label4" runat="server" Style="font-size: x-large">(Franchisee:
                            <asp:Label ID="lblfranchise" runat="server"></asp:Label>)</asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="font-family: Courier New; font-weight: bold;" align="center">
                <td colspan="2" align="center">
                    <asp:Label ID="lblAddres" runat="server" Style="font-size: 18px"></asp:Label>
                </td>
            </tr>
         <%--   <tr style="font-family: Courier New; font-weight: bold;" align="center">
                <td align="center" colspan="2">
                    <asp:Label ID="Label5" runat="server" Style="font-size: 18px">STATE CODE:</asp:Label><asp:Label
                        ID="lblStatecode" runat="server" Style="font-size: 18px"></asp:Label>,&nbsp&nbsp&nbsp
                    <asp:Label ID="Label6" runat="server" Style="font-size: 18px">STATE NO:</asp:Label><asp:Label
                        ID="lblstateno" runat="server" Style="font-size: 18px"></asp:Label>
                </td>
            </tr>--%>
          <%--  <tr style="font-family: Courier New; font-weight: bold;">
                <td colspan="2" align="center">
                    <asp:Label ID="Label7" runat="server" Style="font-size: 18px">Tel No:</asp:Label>
                    <asp:Label ID="lblstoreno" runat="server" Style="font-size: 18px"></asp:Label>
                    <br />
                    <asp:Label ID="lblTINNo" runat="server" Style="font-size: 18px">GSTIN:</asp:Label>
                    <asp:Label ID="lbltin" runat="server" Style="font-size: 18px"></asp:Label>
                    <br />
                    <%--<asp:Label ID="Label9" runat="server" Style="font-size: 18px">FSSAI NO:</asp:Label>--%>
                   <%-- <img id="Img1" style="width: 4pc" src="../images/fssailogo.png" runat="server" />
                    <asp:Label ID="lblfssaino" runat="server" Style="font-size: 18px"></asp:Label>
                </td>
            </tr>--%>
            <%-- <tr id="Tr1" style="width: 100%; height: 35px" runat="server" visible="false">
                <td align="left" width="30%">
                    GST:
                    <asp:Label ID="Label3" runat="server" Text="33AAMCM1387P1ZU"></asp:Label>
                </td>
                <td align="center" width="40%">
                    <asp:Label ID="Label4" runat="server" Text="SRI BALAJI SWEETS AND BAKERY" Font-Bold="true">
                    </asp:Label>
                    <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: 36px"
                        Visible="false"></asp:Label>
                </td>
                <td align="right" width="30%">
                    Ph :
                    <asp:Label ID="Label5" runat="server" Text="044-25585523"></asp:Label>
                </td>
            </tr>--%>
        </table>
        <table border="1" width="595px" class="style1">
            <%-- <tr style="width: 100%; height: 35px">
                <td align="left" width="30%">
                    GST:
                    <asp:Label ID="Label2" runat="server" Text="33AAMCM1387P1ZU"></asp:Label>
                </td>
                <td align="center" width="40%">
                    <asp:Label ID="lblname" runat="server" Text="SRI BALAJI SWEETS AND BAKERY" Font-Bold="true"></asp:Label>
                </td>
                <td align="right" width="30%">
                    Ph :
                    <asp:Label ID="Label1" runat="server" Text="044-25585523"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td colspan="3">
                    <table border="1" width="100%">
                        <tr>
                            <td width="50%" valign="top" colspan="2">
                                <b>Customer Name : </b>
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label><br />
                                <b>PhoneNo : </b>
                                <asp:Label ID="lblCustomerPhoneNo" runat="server"></asp:Label><br />
                                 <b>Address : </b>
                                <asp:Label ID="lblCustomerAddress" runat="server" Style="text-align: center"></asp:Label><br />
                                <b>Vehicle No : </b>
                                <asp:Label ID="lblVehicleNo" runat="server"></asp:Label><br />
                                <b>GST No : </b>
                                <asp:Label ID="lblCusGSTNo" runat="server"></asp:Label>
                            </td>
                            <td width="50%" valign="top" style="border-right: solid 1px">
                                &nbsp; <b>DC No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: </b>
                                <asp:Label ID="lbldcno" runat="server"></asp:Label><br />
                                &nbsp; <b>BillNo &nbsp; : </b>
                                <asp:Label ID="lblBillNo" runat="server"></asp:Label><br />
                                &nbsp; <b>BillDate &nbsp;&nbsp;&nbsp; : </b>
                                <asp:Label ID="lblBillDate" runat="server"></asp:Label><br />
                                &nbsp; <b>PayMode &nbsp;: </b>
                                <asp:Label ID="lblPayMode" runat="server"></asp:Label><br />
                            </td>
                        </tr>
                    </table>
                    <div runat="server" id="divgv">
                        <asp:GridView runat="server" ID="gridprint" GridLines="Both" AutoGenerateColumns="false"
                            ShowHeader="true" Width="100%" Style="font-family: 'Trebuchet MS'; font-size: 13px;">
                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" CssClass="centerHeaderText" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" HeaderStyle-HorizontalAlign="Center"
                                    DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table style="width: 100%; border: solid 1px">
                        <tr style="border: solid 1px">
                            <td style="border-bottom: solid 1px; border-right: solid 1px; width: 30%; text-align: right">
                                <b>Total Items:</b>
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
                        <tr style="border: solid 1px" runat="server" visible="false">
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
                </td>
            </tr>
        </table>
         <div runat="server" id="div2">
            <table border="0" width="595px" class="style1">
                <tr>
                    <td width="50%" valign="top" colspan="2">
                     <%--   <b>Terms : </b>Please make check/cheque payments payable to
                        <asp:Label ID="Label3" runat="server"></asp:Label><br />
                        <br />
                        <b>Payments may also be made by wire transfer to the following account: </b>
                        <br />
                        <b>Account Name : SEKHAR SWEETS</b>
                        <br />
                        <b>Account No : 50200022769625</b><br />
                        <b>Bank : HDFC Bank, Madanapalle</b><br />
                        <b>IFSC Code : HDFC0002435</b><br />--%>
                    </td>
                   <%-- <td align="Right" width="30%">
                    <b>
                        For&nbsp&nbsp<asp:Label ID="lblcompany" runat="server" Style="text-transform: uppercase"></asp:Label><br />
                        <br />
                        <br />                     
                        Authorized Signatory
                        </b>
                    </td>--%>
                </tr>
            </table>
        </div>
        <table width="595px" height="5px" class="style1">
            <tr>
                <td align="center">
                    <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction()" />
                    <asp:Button ID="btnexit" runat="server" Text="Exit" PostBackUrl="~/Accountsbootstrap/WholeSalesGrid.aspx" />
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
