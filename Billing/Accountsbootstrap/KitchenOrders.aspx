<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitchenOrders.aspx.cs" Inherits="Billing.Accountsbootstrap.KitchenOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Refresh" content="5">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
     <link href="../css/Pos_style.css" rel="stylesheet" />
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
<body onload="startTime()">
    <form id="form1" runat="server">
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Kitchen Orders</h1>
	    </div>
    <div class="panel-body" >
   
    <h3 style="color:#0073e4">Date :<asp:Label ID="lbldate" runat="server"></asp:Label> 
    &nbsp; <asp:Label ID="Label1" runat="server"></asp:Label> &nbsp &nbsp &nbsp <asp:Label ID="lblKOT" runat="server"> 
    </asp:Label>
    </h3>
  
    <div class="col-lg-12">
    <asp:DataList ID="datkot"   runat="server" RepeatColumns="5" RepeatDirection ="Horizontal" RepeatLayout="Table" Width="100%" CssClass="table table-responsive">
    <ItemTemplate>
    <div  class="row">
      <div class="col-lg-12">
   <div class="panel panel-primary">
   <div class="panel-header"> 
   <h1 class="page-header">Bill No:<asp:Label ID="lblkotno" runat="server" Text='<%# Eval("billno") %>'></asp:Label>
    &nbsp &nbsp &nbsp
   Type:<asp:Label ID="Label2" runat="server" Text='<%# Eval("Type") %>'></asp:Label></h1>
   </div>
  
   <div class="panel-body" >
    <div class="hidden" >
     <asp:Label ID="lbltbl" runat="server" Text='<%#Eval("billno") %>'></asp:Label>
    </div>
    <div class="hidden">
     <asp:Label ID="lblpax" runat="server" Text="Pax 1"></asp:Label>
    </div>
  
    <div class="col-lg-12" >
    <asp:GridView ID="gvitems"  cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" runat="server" AutoGenerateColumns="false" Width="100%">
    <%--<HeaderStyle BackColor="#428bca"  ForeColor="White"   /> --%>   
    <Columns>
    <asp:BoundField HeaderText="Item Name" DataField="Definition" ItemStyle-Font-Bold="true" ItemStyle-Font-Size="X-Large" />
    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
    <asp:BoundField  DataField="KotDate"  ItemStyle-CssClass="hidden"/>
   
    </Columns>
    </asp:GridView><br />
    </div>
    <div class="row" align="center">
    <asp:Button ID="btn" runat="server" CssClass="btn btn-primary pos-btn1" CommandArgument='<%#Eval("billno") %>' Text="Complete" OnClick="btncomplete" />
      <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary pos-btn1" Visible="false" CommandArgument='<%#Eval("billno") %>' Text="Print" OnClick="btn_print" />
    </div>
    </div>
    </div>
    </div>
    </div>
    </ItemTemplate>
    
    </asp:DataList>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
