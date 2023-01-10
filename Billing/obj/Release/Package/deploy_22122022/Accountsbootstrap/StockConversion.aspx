<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockConversion.aspx.cs" Inherits="Billing.Accountsbootstrap.StockConversion" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="head" >

   <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>PO Form</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>
      <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css"  />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function alertMessage() {
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
	<style type="text/css">

.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 0;
background-color: Black;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.8;
}
.GridviewDiv {font-size: 100%; font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif; color: #303933;}
.headerstyle
{
color:#FFFFFF;border-right-color:#abb079;border-bottom-color:#abb079;background-color: #df5015;padding:0.5em 0.5em 0.5em 0.5em;text-align:center;
}
</style>

    <link href="../Styles/chosen.css" rel="stylesheet" type="text/css" />
</head> 
<body style="">
<usc:Header ID="Header" runat="server" />

<form runat="server" id="form1" method="post">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="Panel1" runat="server" UpdateMode="Conditional"   EnableViewState="true" >
<ContentTemplate>
         <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   
    <div class="row" style="margin-top:0px" align="center" >
                <div class="col-lg-12" style="padding-top:0px">
                    <h1 class="page-header">Stock Converter</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row" style="">
                <div >
                    <div class="panel panel-default" style="">
                        
                        <div class="panel-body" style="">
                            
                                    
                                    <div class="form-group" style="" align="center">
                                            <label>Sponge in Stock</label>
                                          
                                                <asp:GridView ID="gvGoodsReceived" runat="server" AllowPaging="true"  CssClass="mGrid"
                                                PageSize="10"  Width="80%"
                                        AutoGenerateColumns="false" 
                                                onrowdatabound="gvGoodsReceived_RowDataBound" 
                                                onpageindexchanging="gvGoodsReceived_PageIndexChanging" onselectedindexchanged="gvGoodsReceived_SelectedIndexChanged" 
                                       
                                          >
                                 <HeaderStyle BackColor="#990000" />
                                <PagerSettings  Mode="Numeric"  />
                                <AlternatingRowStyle Width="200px" />
    <Columns>
    <asp:BoundField HeaderText="Group" DataField="Category" />
    <asp:BoundField HeaderText="Item Name" DataField="Definition"  />
    <asp:BoundField HeaderText="Item ID" DataField="SubCategoryID" />
     <asp:BoundField HeaderText="ID" DataField="Stockid" />
    <asp:BoundField HeaderText="Qty/Nos" DataField="Available_Qty"  DataFormatString='{0:N1}' />
     <asp:BoundField HeaderText= "Avl-Qty/kg" DataField="Weight"  DataFormatString='{0:N1}' />
     <asp:TemplateField HeaderText ="Used Qty/kg" >
   <ItemTemplate>
  <asp:TextBox ID="txtUsing" CssClass="form-control" Width="100px" runat="server"  ></asp:TextBox>
   </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText ="Convert To Category">
   <ItemTemplate>
   <asp:DropDownList ID="ddlcategory" Width="170px" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" ></asp:DropDownList>
   </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText ="CategoryID" Visible="false" >
   <ItemTemplate>
  <asp:TextBox ID="txtCatID" CssClass="form-control"   Visible="false"  runat="server"></asp:TextBox>
   </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText ="Convert To Item">
   <ItemTemplate>
   <asp:DropDownList ID="ddlItems" runat="server"  Width="170px"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged" ></asp:DropDownList>
   </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText ="SubCategoryId" Visible="false"  >
   <ItemTemplate>
  <asp:TextBox ID="txtItem" CssClass="form-control" Visible="false"  runat="server"></asp:TextBox>
   </ItemTemplate>
   </asp:TemplateField>
     <asp:TemplateField HeaderText =" Units">
   <ItemTemplate>
 <asp:DropDownList ID="ddlUnits" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnits_SelectedIndexChanged" CssClass="form-control"  Width="100px"  >
 <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                           
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
 </asp:DropDownList>
   </ItemTemplate>
   </asp:TemplateField>
     <asp:TemplateField HeaderText ="Unitsid" Visible="false"  >
   <ItemTemplate>
  <asp:TextBox ID="txtUnits" CssClass="form-control" Visible="false"  runat="server"></asp:TextBox>
   </ItemTemplate>
   </asp:TemplateField>

    <asp:TemplateField HeaderText ="Converting Qty">
   <ItemTemplate>
  <asp:TextBox ID="txtQty" CssClass="form-control" runat="server" Width="100px"></asp:TextBox>
   </ItemTemplate>
   </asp:TemplateField>
  
     <asp:TemplateField HeaderText ="ExpiryDate">
   <ItemTemplate>
  <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" Width="150px"></asp:TextBox>
     <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
   </ItemTemplate>
   </asp:TemplateField>
    <asp:BoundField HeaderText="SpongeExpDate" DataField="Expirydate" />
    </Columns>
     
 <FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   </asp:GridView>                                               
                                                  

                                               
                                        
                                        </div> 
                                        <div align="center" style="">
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Convert"   Height="40px"
                                                style="margin-top: 10px;" onclick="btnsearch_Click"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"   Height="40px"
                                                style="margin-top: 10px;"  /> 
                                       <label id="lblcatID" runat="server"></label>
                                        </div>
                               

                               <div class="table-responsive" style="">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td style="">

                                
                               
                                </td>
                                <td style="">
                                <asp:GridView ID="gvDetails" runat="server" CssClass="myGridStyle" AutoGenerateColumns="false">

                                <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Category" />
     <asp:BoundField HeaderText="Category" DataField="Definition" />
     <asp:BoundField HeaderText="Qty" DataField="Qty" />
          <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" />
    

                                </Columns>
   <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />                     
                                </asp:GridView>
                                </td>
                                </tr>
                                </table>
                                
                                </div>



                                     
                              </div>
                              </div></div></div></div> 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="gvGoodsReceived" />
</Triggers>
</asp:UpdatePanel>

<asp:UpdatePanel ID="update" runat="server"   EnableViewState="true" UpdateMode="Conditional">
                        <ContentTemplate>
                         
                        <div id="horizontalTab" runat="server">
                       
        <ul>
            <li><a href="#tab-1" >Gateaux</a></li>
            <li><a href="#tab-2">Snacks</a></li>
            <li><a href="#tab-3">Puddings</a></li>
            <li><a href="#tab-4">Beverages</a></li>
            <li><a href="#tab-5">Sweets</a></li>
             <li><a href="#tab-6">Candles</a></li>
            <li><a href="#tab-7">Mousse</a></li>
             <li><a href="#tab-8">Extras</a></li>
              <li><a href="#tab-9">Cheese cak</a></li>
               <li><a href="#tab-10">Salads</a></li>
               <li><a href="#tab-11">Birthday Cakes</a></li>
               <li><a href="#tab-12">Breads</a></li>
        </ul>
        
        <div id="tab-1">
       <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvPuffs" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
             
                                </div>
                                <div id="tab-2">
                                <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvBuns" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                            
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-3">
           <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvCakes" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                               
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-4">
            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvBread" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                              
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-5">
           <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvCookies" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-6">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvcandles" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-7">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvMousse" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-8">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="GridView1" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-9">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="GridView2" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-10">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="GridView3" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-11">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvBday" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-12">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView id="gvbr" runat="server"  AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField  HeaderText="category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="categoryID" DataField="CategoryID" />
                                <asp:BoundField  HeaderText="SubcategoryID" DataField="CategoryUserID" />
                                <asp:TemplateField HeaderText ="Qty">
                                <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" CssClass="form-control">0</asp:TextBox>
                                </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText ="Units">
                                <ItemTemplate>
                                <asp:DropDownList id="ddUnits" runat="server" CssClass="form-control">
                               <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Nos" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />               
                                </asp:GridView>
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div  class="form-group">
                            
                              <asp:Label ID="lblError" runat="server" style="color:Red"></asp:Label>
                                

									
            
                                        
                                        
                                         
                                        
                            </div>
                            <script src="js/jquery.responsiveTabs.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var $tabs = $('#horizontalTab');
            $tabs.responsiveTabs({
                rotate: false,
                startCollapsed: 'accordion',
                collapsible: 'accordion',
                setHash: true,

                activate: function (e, tab) {
                    $('.info').html('Tab <strong>' + tab.id + '</strong> activated!');
                },
                activateState: function (e, state) {
                    //console.log(state);
                    $('.info').html('Switched from <strong>' + state.oldState + '</strong> state to <strong>' + state.newState + '</strong> state!');
                }
            });

            /* $('#start-rotation').on('click', function () {
            $tabs.responsiveTabs('startRotation', 1000);
            });
            $('#stop-rotation').on('click', function () {
            $tabs.responsiveTabs('stopRotation');
            });
            $('#start-rotation').on('click', function () {
            $tabs.responsiveTabs('active');
            });
            $('#enable-tab').on('click', function () {
            $tabs.responsiveTabs('enable', 3);
            });
            $('#disable-tab').on('click', function () {
            $tabs.responsiveTabs('disable', 3);
            });
            $('.select-tab').on('click', function () {
            $tabs.responsiveTabs('activate', $(this).val()); */

        });

        
    </script>         
    </div>
                        </ContentTemplate>
                        <Triggers>
                       
                        </Triggers>
                        </asp:UpdatePanel>
     <script src="Scripts/jquery.min.js" type="text/javascript"></script>
		<script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script type="text/javascript">		    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                                    
                                  
                                    </form>
                              



</body>

</html>
