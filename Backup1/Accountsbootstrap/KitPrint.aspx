<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitPrint.aspx.cs" Inherits="Billing.Accountsbootstrap.KitPrint" %>

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
            <table width="300px">
                <tr>
                    <td align="center">
                        <label style="font-weight: bold; font-size: larger">
                            KITCHEN CAKE ORDER</label><br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <label style="font-weight: bold; font-size: larger">
                            Branch Name:<asp:Label ID="lblbnch" runat="server"></asp:Label>
                        </label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            OrderNo:
                        </label>
                        <asp:Label ID="lblOrderNo" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            BookNo:
                        </label>
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
                <tr id="tremp" runat="server" visible="false">
                    <td>
                        <label style="font-weight: bold; font-size: larger">
                            Employee Name :
                        </label>
                        <asp:Label ID="lblemp" runat="server" Style="font-weight: bold; font-size: larger"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="font-weight: bold; font-size: larger">
                        <asp:GridView ID="gvPrint" runat="server" Width="265px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:N1}" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Packing Notes" DataField="Packingnotes" DataFormatString="{0:N1}" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <%--<asp:ImageField HeaderText="Cake Img."  ></asp:ImageField>--%>
                                <asp:TemplateField Visible="false" HeaderText="Cake.Img">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="122px" ImageUrl='<%# Eval("Modelimgpath") %>'
                                            Width="148px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
                <tr>
                    <td style="font-weight: bold; font-size: larger">
                        <label>
                            Delivery Date:</label>
                        <asp:Label ID="lblDeliveryDate" runat="server" Font-Size="Smaller"></asp:Label>-
                        <asp:Label ID="lblTime" runat="server" Font-Size="Smaller"></asp:Label>
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
