<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="twoinchprint.aspx.cs" Inherits="Billing.Accountsbootstrap.twoinchprint" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="style.css">
    <title>Receipt example</title>
    <style>
        * {
            font-size: 12px;
            font-family: 'Times New Roman';
        }

        td,
        th,
        tr,
        table {
            border-top: 1px solid black;
            border-collapse: collapse;
        }

            td.description,
            th.description {
                width: 75px;
                max-width: 75px;
            }

            td.quantity,
            th.quantity {
                width: 40px;
                max-width: 40px;
                word-break: break-all;
            }

            td.price,
            th.price {
                width: 40px;
                max-width: 40px;
                word-break: break-all;
            }

        .centered {
            text-align: center;
            align-content: center;
        }

        .ticket {
            width: 180px;
            max-width: 180px;
        }

        img {
            max-width: inherit;
            width: inherit;
        }

        @media print {
            .hidden-print,
            .hidden-print * {
                display: none !important;
            }
        }
    </style>
</head>
<body onload="window.print()">
    <div class="ticket">
        <img runat="server" visible="false" src="./logo.png" alt="Logo">
        <p class="centered">
            <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: 15px"
                Visible="true"></asp:Label>
            <br />
            (Take Away)
                <br>
            <asp:Label ID="lblAddres" runat="server" Style="font-size: 10px;" Visible="true"></asp:Label><br />
            <asp:Label ID="lblmobilename" runat="server" Visible="false" Text="Tel No."></asp:Label>
            <asp:Label ID="lblmobilename1" runat="server" Visible="false" Text="Mobile No."></asp:Label>
            <asp:Label ID="lblstoreno" runat="server" Style="font-size: 10px"></asp:Label>
            <br />
            <div id="lblgstdetails" runat="server" visible="false">
                <asp:Label ID="lblTINNo" runat="server" Style="font-size: 10px">GSTIN:</asp:Label>
                <asp:Label ID="lbltin" runat="server" Style="font-size: 10px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Style="font-size: 10px">/ FSSAI NO:</asp:Label>
                <asp:Label ID="lblfssaino" runat="server" Style="font-size: 10px"></asp:Label>

            </div>
        </p>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblbillname" runat="server" Font-Size="10px" Font-Bold="true"  ></asp:Label>:
                    <asp:Label ID="lblbillno" runat="server" Style="font-size: 10px"></asp:Label>
                </td>
                <td style="padding-left: 2px" >
                    <asp:Label ID="lblsalestype" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label><br />
                        <asp:Label ID="lblorderno" Font-Size="10px" Font-Bold="true" runat="server" Visible="false"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="2" >Bill Date:
                    <asp:Label ID="lblbilldate" runat="server" Style="font-size: 10px"></asp:Label>
                </td>
            </tr>
        </table>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />

        <table runat="server" visible="false">
            <thead>
                <tr>
                    <th class="quantity">Q.</th>
                    <th class="description">Description</th>
                    <th class="price">$$</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="quantity">1.00</td>
                    <td class="description">ARDUINO UNO R3</td>
                    <td class="price">$25.00</td>
                </tr>
                <tr>
                    <td class="quantity">2.00</td>
                    <td class="description">JAVASCRIPT BOOK</td>
                    <td class="price">$10.00</td>
                </tr>
                <tr>
                    <td class="quantity">1.00</td>
                    <td class="description">STICKER PACK</td>
                    <td class="price">$10.00</td>
                </tr>
                <tr>
                    <td class="quantity"></td>
                    <td class="description">TOTAL</td>
                    <td class="price">$55.00</td>
                </tr>
            </tbody>
        </table>
        <table id="tblgrand" runat="server" visible="false" style="margin-left: 73px;" >
            <tr align="right">
                <td></td>
                <td>Total :
                    <asp:Label ID="lblGrand" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
        <p class="centered">
            Thanks for your purchase!
                <br>
            <div runat="server" style="font-size:10px" >
                <b>
            Tech.partner : www.bigdbiz.com</b>
                </div>
        </p>
            
    </div>
    <button id="btnPrint" runat="server" visible="false" class="hidden-print">Print</button>
    <script src="script.js"></script>
</body>
</html>
