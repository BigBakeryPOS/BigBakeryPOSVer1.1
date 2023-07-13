<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginType.aspx.cs" Inherits="Billing.LoginType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <!-- Somehow I got an error, so I comment the title, just uncomment to show -->
    <!-- <title>Transparent Login Form UI</title> -->
    <link href="../css/LoginBranch.css" rel="stylesheet" type="text/css" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <style>
        .brightness
        {
            background-color: Red;
            display: inline-block;
        }
        .brightness img:hover
        {
            opacity: .5;
        }
    </style>
</head>
<body style="background: #057fe9">
    <form id="form1" runat="server">
    <div align="center">
        <label style="color: White">
            APPLICATION VERSION:</label>
        <asp:Label ID="lblversion" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="White"
            Text="1.1"></asp:Label>
        <asp:Label ID="macaddress" runat="server" Visible="false" Style="color: White"></asp:Label></div>
    <div class="container">
        <div class="img-cont">
            <table width="100%">
                <tr>
                    <td style="width: 5%">
                    </td>
                    <td style="width: 30%">
                        <div class="img-cont">
                            <asp:LinkButton ID="btndel" PostBackUrl="~/Accountsbootstrap/Login_Prod.aspx" runat="server">
                                <asp:Image ID="Image1" ImageUrl="~/images/Production.png" Width="80%" Height="40pc" runat="server" />
                            </asp:LinkButton>
                            <div align="center" >
                            <asp:Label runat="server" Text="PRODUCTION" Font-Bold="true" Font-Size="25px" ></asp:Label>
                                </div>
                            <%-- <img src="images/Production_logo.jpeg">--%>
                        </div>
                    </td>
                    <td style="width: 30%">
                        <div class="img-contt">
                            <asp:LinkButton ID="LinkButton1" PostBackUrl="~/Accountsbootstrap/Login_BRANCH.aspx?type=2"
                                runat="server">
                                <asp:Image ID="Image2" ImageUrl="~/images/shop.png" Width="80%" Height="40pc" runat="server" />
                            </asp:LinkButton>
                            <div align="center" >
                            <asp:Label runat="server" Text="OUTLET" Font-Bold="true" Font-Size="25px" ></asp:Label>
                                </div>
                            <%--<img src="images/Shop_logo.jpeg">--%>
                        </div>
                    </td>
                    <td style="width: 30%">
                        <div class="img-contt">
                            <asp:LinkButton ID="LinkButton2" PostBackUrl="~/Accountsbootstrap/Login_store.aspx"
                                runat="server">
                                <asp:Image ID="Image3" ImageUrl="~/images/store.jpg" Width="80%" Height="40pc" runat="server" />
                            </asp:LinkButton>
                            <div align="center" >
                            <asp:Label runat="server"  Text="STORE" Font-Bold="true" Font-Size="25px" ></asp:Label>
                                </div>
                            <%--<img src="images/Store_logo.jpeg">--%>
                        </div>
                    </td>
                    <td style="width: 5%">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
