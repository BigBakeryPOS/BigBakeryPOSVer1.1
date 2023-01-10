<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerOrder.aspx.cs" Inherits="Billing.Accountsbootstrap.DealerOrder" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width,initial-scale=1.0" />
  <title>Production Stock</title>
  <meta name="description" content="Responsive tabbed layout component built with some CSS3 and JavaScript" />
  <link rel="stylesheet" href="Tabs/css/font-awesome.min.css" />
  <link rel="stylesheet" href="Tabs/css/style.min.css" />
  <link rel="apple-touch-icon" href="/apple-touch-icon.png" />
  <link rel="icon" type="image/png" href="/favicon.png" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>


 <style>
     .Hide
     {
         display:none;}
         
			.ontop {
				z-index: 999;
				width: 100%;
				height: 100%;
				top: 0;
				left: 0;
				bottom;0;
				display: none;
				position: absolute;				
				background-color: #cccccc;
				color: #aaaaaa;
				opacity: .4;
				filter: alpha(opacity = 50);
			}
			#popup {
				width: 300px;
				height: 200px;
				position: absolute;
				bottom;0;
				color: #000000;
				background-color: #ffffff;
				/* To align popup window at the center of screen*/
				top: 50%;
				left: 50%;
				margin-top: -100px;
				margin-left: -150px;
			}
		</style>
		<script type="text/javascript">
		    function pop(div) {
		        document.getElementById(div).style.display = 'block';
		        document.getElementById("btnsave").click();
		    }
		    function hide(div) {
		        document.getElementById(div).style.display = 'none';
		    }
		    //To detect escape button
		    document.onkeydown = function (evt) {
		        evt = evt || window.event;
		        if (evt.keyCode == 27) {
		            hide('popDiv');
		        }
		    };
		</script>
</head>
<body>
 
 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>

                    <form runat="server" id="form1" method="post">
<header class="o-header" >
  
  <div class="o-container">
    <h1 class="o-header__title">Item List</h1>
  </div>
  <div class="o-container" style="display:none">
  <asp:TextBox ID="txtpono"  runat="server"></asp:TextBox>
  <asp:TextBox ID="txtpodate"  runat="server"></asp:TextBox>
  </div>
  <div class="o-container" style="display:none">
  <asp:DropDownList ID="ddlvendor" runat="server"></asp:DropDownList>
  </div> 
  <div class="o-container" ><b>Orderded By</b>
  <asp:TextBox ID="txtOrderBy"  Width="200px" Height="35px" runat="server" Placeholder="Name"></asp:TextBox>
  
  </div>
</header>

<main class="o-main" align="center">
  <div class="o-container" style="margin-left:-50px">

    <div class="o-section">
      <div id="tabs" class="c-tabs no-js">
        <div class="c-tabs-nav">
          <a href="#" class="c-tabs-nav__link is-active">
          
            <span>Gateaux</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
            
            <span>Snacks</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
           
            <span>Puddings</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
           
            <span>Beverages</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
           
            <span>Sweets</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
           
            <span>Party</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
            
            <span>Moouse</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
           
            <span>Cookies</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
            
            <span>Cheese</span>
          </a>
          
           <a href="#" class="c-tabs-nav__link">
           
            <span>Stores</span>
          </a>
           <a href="#" class="c-tabs-nav__link">
           
            <span>BDC</span>
          </a>
           <a href="#" class="c-tabs-nav__link">
          
            <span>Breads</span>
          </a>
           <a href="#" class="c-tabs-nav__link">
            
            <span>Sponges</span>
          </a>

          <a href="#" class="c-tabs-nav__link">
            
            <span>ReadyMade Sponges</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
            
            <span>ReadyMade Cakes</span>
          </a>
          <a href="#" class="c-tabs-nav__link">
            
            <span>Ice Creams</span>
          </a>

        </div>
        <div class="c-tab is-active">
          <div class="c-tab__content">
                                            <asp:GridView id="gvGateaux" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                <asp:BoundField  HeaderText="SubcategoryID"    DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                      
                        
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
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvSnacks" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvPuddings" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                              
                                
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvBeverages" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                 <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                              
                             
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />              
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvSweets" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid">
                                 <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />      
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvcandles" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid" >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"   ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />         
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvMousse" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />      
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvCookies" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid" >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />     
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvcheese" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid" >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />              
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvStores" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                 <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />         
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvBday" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                 <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />            
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
           <asp:GridView id="gvbread" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="mGrid"  >
                                  <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"   ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />       
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
            <asp:GridView id="gvSponges" runat="server"  AutoGenerateColumns="false" 
                                         CssClass="mGrid" >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />   
                                </asp:GridView>
          </div>
        </div>
        <div class="c-tab">
          <div class="c-tab__content">
          <asp:GridView id="gvReadySp" runat="server"  AutoGenerateColumns="false" 
                                         CssClass="mGrid" >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />   
                                </asp:GridView>
          </div>
          </div>
         <div class="c-tab">
          <div class="c-tab__content">
          <asp:GridView id="gvRmCake" runat="server"  AutoGenerateColumns="false" 
                                         CssClass="mGrid" >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />   
                                </asp:GridView>
          </div>
          </div>
          <div class="c-tab">
          <div class="c-tab__content">
          <asp:GridView id="gvIce" runat="server"  AutoGenerateColumns="false" 
                                         CssClass="mGrid" >
                                <Columns>
                                <asp:BoundField  HeaderText="Group" DataField="Category"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition"  HeaderStyle-Font-Size="Smaller"/>
                                <asp:BoundField  HeaderText="categoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                <asp:BoundField  HeaderText="SubcategoryID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                      
                        
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />   
                                </asp:GridView>
          </div>
          </div>
      </div>
    </div>

    <div class="o-section">
      <asp:Button ID="btnsave" runat="server" Text="Place Order"   OnClientClick="pop('popDiv')" 
            style="width:200px;height:50px;background-color:#de446e;color:White" 
            onclick="btnsave_Click" />
    </div>
    <div id="popDiv" class="ontop">
			<table border="1" id="popup" style="background-color:Red">
            <tr>
            <td align="center" style="color:White">
        <b>Please Wait.................</b>    
            </td>
            </tr>
				
			</table>
		</div>
    <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="../images/Preloader_10.gif" alt="" />
</div>
  </div>
</main>

<footer class="o-footer">
  <div class="o-container">
    <small>&copy; 2016, www.Bigbbiz.in</small>
  </div>
</footer>
<script  type="text/javascript"src="Tabs/js/src/tabs.js"></script>
<script type="text/javascript">
    var myTabs = tabs({
        el: '#tabs',
        tabNavigationLinks: '.c-tabs-nav__link',
        tabContentContainers: '.c-tab'
    });

    myTabs.init();
</script>

<!-- EXTERNAL SCRIPTS FOR CALLMENICK.COM, PLEASE DO NOT INCLUDE -->
<script type="text/javascript" src="Tabs/js/lib/githubicons.js"></script>
<script type="text/javascript" src="Tabs/js/lib/carbonad.js"></script>
<script type="text/javascript">
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
    ga('create', 'UA-34160351-1', 'auto');
    ga('send', 'pageview');
</script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


</form>
</body>
</html>