<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingridients.aspx.cs" Inherits="Bakery.Ingridients" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
   
</head>
<body  style="background-color:#f7f3e6">
    <form id="form1" runat="server">
    <div class="row" style="margin-top:200px;margin-left:30px">
    <div></div>
    <legend>Ingredients</legend>
    <div class="table-responsive " ></div>
    <table border="1" style="border-color:#f7f3e6;width:auto">
    <tr>
     <th >Ingredient Name</th>
      <th>Suppliername Name</th>
       <th> Cost /kilo</th>
        <th>Kilos pr. bag/box</th>
        <th></th>
    
    </tr>
    <tr>
    <td>
    <asp:TextBox id="txtingre" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="txtsupplier" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
   <asp:TextBox id="txtcost" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="txtkgbox" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:Button ID="btnadd" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="ingrid" runat="server" AutoGenerateColumns="False" 
                      AllowPaging="True" PageSize="8" 
                      CssClass="myGridStyle">                  
                                    
                                 <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" 
                                     PreviousPageText="Previous" />   
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
         <Columns>
          <asp:BoundField DataField="Ingredients"   />
         <asp:BoundField DataField="Supplier"   />
         <asp:BoundField DataField="Cost"  />
         <asp:BoundField DataField="Kilo"  />
         
        <%-- <asp:TemplateField HeaderText="Reviewer Status">
         <ItemTemplate>
         <asp:LinkButton ID="lnkStats" CommandName="Link" CommandArgument='<%#Eval("AssignId")%>' Text="AdminStatus" runat="server"></asp:LinkButton>
         </ItemTemplate>
         </asp:TemplateField>

          <asp:TemplateField HeaderText="Reviewer Status">
         <ItemTemplate>
         <asp:LinkButton ID="comment" CommandName="comment" CommandArgument='<%#Eval("AssignId")%>' Text="Comments History" runat="server"></asp:LinkButton>

          
         </ItemTemplate>
         </asp:TemplateField>--%>
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   </tbody>
    </table>
   
    
    </div>
    </form>
</body>
</html>
