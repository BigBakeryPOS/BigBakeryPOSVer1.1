<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productiontostock.aspx.cs" Inherits="Billing.Accountsbootstrap.Productiontostock" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="tab" runat="server">
    <ajaxToolkit:TabPanel HeaderText="Snacks" runat="server" ID="snacks">
    <ContentTemplate>
    <div>
  <div>
    <h1>2</h1>
    <asp:GridView id="gvSnacks" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField  HeaderText="SubcategoryID"    DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField  HeaderText="Existing Qty" DataField="Prod_Qty"  HeaderStyle-Font-Size="Smaller"/>
                        
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server">
                               
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                               <FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#de446e"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
    </div>
    </div>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel HeaderText="Gateaux" runat="server" ID="Sweets">
    <ContentTemplate>
    <div>
    <h1>2</h1>
    <asp:GridView id="gvGateaux" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField  HeaderText="SubcategoryID"    DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField  HeaderText="Existing Qty" DataField="Prod_Qty"  HeaderStyle-Font-Size="Smaller"/>
                        
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server">
                               
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                               <FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#de446e"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
    </div>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>


    <ajaxToolkit:TabPanel HeaderText="Pudding" runat="server" ID="Cakes">
    <ContentTemplate>
    <div>
    <div>
    <h1>2</h1>
    <asp:GridView id="gvPuddings" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField  HeaderText="SubcategoryID"    DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField  HeaderText="Existing Qty" DataField="Prod_Qty"  HeaderStyle-Font-Size="Smaller"/>
                        
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server">
                               
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                               <FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#de446e"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
    </div>
    </div>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>


    <ajaxToolkit:TabPanel HeaderText="Beverages" runat="server" ID="Lunch">
    <ContentTemplate>
    <div>
    <div>
    <h1>2</h1>
    <asp:GridView id="gvBeverages" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField  HeaderText="SubcategoryID"    DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:BoundField  HeaderText="Existing Qty" DataField="Prod_Qty"  HeaderStyle-Font-Size="Smaller"/>
                        
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server">
                               
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                               <FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#de446e"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
    </div>
    </div>
    </ContentTemplate>
    </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </div>
    </form>
</body>
</html>
