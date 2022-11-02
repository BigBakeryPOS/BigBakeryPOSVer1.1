<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineOrderScreen.aspx.cs"
    Inherits="Billing.Accountsbootstrap.OnlineOrderScreen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Refresh" content="5">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script>
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('Label1').innerHTML =
    h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
            return i;
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div class="panel panel-body">
        <div class="panel-danger">
            <h3 style="color: Green">
                Date :<asp:Label ID="lbldate" runat="server"></asp:Label>
                &nbsp
                <asp:Label ID="Label1" runat="server"></asp:Label>
                &nbsp &nbsp &nbsp
                <asp:Label ID="lblKOT" runat="server"> </asp:Label></h3>
        </div>
        <div class="col-lg-12">
            <asp:DataList ID="datkot" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                RepeatLayout="Table" Width="100%" CssClass="table table-responsive">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel panel-heading" style="padding-bottom: -50px">
                                <asp:Label ID="lblonlineid" Visible="false" runat="server" Text='<%# Eval("onlineid") %>'></asp:Label>
                                    Order No:<asp:Label ID="lblkotno" Font-Bold="true" Font-Size="30px" runat="server" Text='<%# Eval("OnlineNumber") %>'></asp:Label>
                                    &nbsp &nbsp &nbsp Type:<asp:Label ID="Label2" Font-Bold="true" Font-Size="30px" runat="server" Text='<%# Eval("PaymentType") %>'></asp:Label></div>
                                <div class="panel" style="padding-top: -50px">
                                    <div class="hidden">
                                        <asp:Label ID="lbltbl" runat="server" Text='<%#Eval("OnlineNumber") %>'></asp:Label>
                                    </div>
                                    <div class="hidden">
                                        <asp:Label ID="lblpax" runat="server" Text="Pax 1"></asp:Label>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="false" Width="100%">
                                            <HeaderStyle BackColor="#428bca" ForeColor="White" />
                                            <Columns>

                                                <asp:BoundField HeaderText="Item Name" DataField="Definition" />
                                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                                <asp:BoundField DataField="EntryDate" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                <asp:BoundField HeaderText="Item Id" DataField="subcategoryid" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                <asp:BoundField HeaderText="Avl.Stock" DataField="Available_QTY"   />
                                            
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="row" align="center">
                                        <asp:Button ID="btn" runat="server" CssClass="btn btn-danger" CommandArgument='<%#Eval("onlineid") + "," + Eval("PaymentType") + "," + Eval("OnlineNumber") %>'
                                            Text="Complete" OnClick="btncomplete" />
                                        <asp:Button ID="Button1" runat="server" Visible="false" CssClass="btn btn-danger" CommandArgument='<%#Eval("onlineid") + "," + Eval("PaymentType") + "," + Eval("OnlineNumber") %>'
                                            Text="Print" OnClick="btn_print" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    </form>
</body>
</html>
