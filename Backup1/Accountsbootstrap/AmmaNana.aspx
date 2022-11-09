<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmmaNana.aspx.cs" Inherits="Billing.Accountsbootstrap.AmmaNana" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
   
    window.print();
    
    </script>
</head>
<body onload="print()">
    <form id="form1" runat="server" >
    <div align="center">
    <table border="1"  >  
    <tr align="center" style="background-color:#d6e3bc;color:Black">
    <td colspan="5">
    <h1>LA PAPILLA</h1>
    </td>
    </tr>
    <tr align="center">
    <td >
   <label><b>100, chamiers Road, Alwarpet, Chennai – 600018. <br />
  Ph :044-42051515, Our TIN No.-33900863527	</b>								
	
</label>
    </td>
    </tr>
    <tr align="center">
    <td>
    <label><b>Buyer Name</b> 								
							
</label>
<asp:Label ID="lbldealername" runat="server">AMMA NAANA</asp:Label>
    </td>
    </tr>
    <tr align="right">
    <td >
    <label > <b>Inv.No.</b>
</label><asp:Label ID="lblInvNo" runat="server"></asp:Label><br />
<label><b> Bill Date</b> 
</label><asp:Label ID="lblBillDate" runat="server"></asp:Label>
    </td>
    </tr>
    <tr  valign="top"  >
    <td style="height:300px"  >
    <asp:GridView ID="gvDetails" Width="100%" runat="server" GridLines="Vertical"    AutoGenerateColumns="false" HeaderStyle-BackColor="#d6e3bc" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Black">
    <Columns>
    <asp:BoundField HeaderText="Description" DataField="Definition" />
    <asp:BoundField HeaderText="Sub Group" DataField="Category" />
    <asp:BoundField HeaderText="Rate" DataField="User1" />
    <asp:BoundField HeaderText="Qty" DataField="Quantity" />
    <asp:BoundField HeaderText="Basis Price" DataField="Basic" />
    <asp:BoundField HeaderText="Margin" DataField="Margin" />
    <asp:BoundField HeaderText="Sales Exempted" DataField="Exempted" ItemStyle-HorizontalAlign="Right"  />
    <asp:BoundField HeaderText="Sales @ 5%" DataField="NetAmount" ItemStyle-HorizontalAlign="Right"  />
    <asp:BoundField HeaderText="VAT 5%" DataField="Vat" ItemStyle-HorizontalAlign="Right"  />
    <asp:BoundField HeaderText="Total Sales" DataField="Total" ItemStyle-HorizontalAlign="Right" />
    </Columns>
    </asp:GridView>
    </td>
    </tr>
    <tr >
    <td align="right"><table border="0"><tr>
     <td style="padding-right:100px"><label><b>Total</b></label></td>
    <td style="padding-right:60px"><asp:Label ID="lblExepTotal" runat="server"></asp:Label></td>
    <td  style="padding-right:30px"><asp:Label ID="lblNet" runat="server"></asp:Label></td>
    <td  style="padding-right:40px"><asp:Label ID="lblVatTotal" runat="server"></asp:Label></td>
    <td  style=""><asp:Label ID="LblGrandTotal" runat="server"></asp:Label></td>
    </tr>
    <tr align="right"  >
   
     <td style="padding-right:100px"><label><b>Grand Total</b></label></td>
     <td></td>
      <td></td>
       <td></td>
    <td  ><asp:Label ID="lblGrand" runat="server"></asp:Label></td>
    </tr>
    
    </table></td>
   


    </tr>
    
    <tr style="background-color:#d6e3bc">
    <td>
    <label><b>AMOUNT</b></label>
    <asp:Label id="lblwords" runat="server"></asp:Label>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
