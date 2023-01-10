<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseRequest.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchaseRequest" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1">
<script language="javascript" type="text/javascript">

    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else

            event.returnValue = false;
    }

</script>


<script type="text/javascript">
    function printGrid() {
        var gridData = document.getElementById('<%= GridView1.ClientID %>');
        var windowUrl = 'about:blank';
        //set print document name for gridview
        var uniqueName = new Date();
        var windowName = 'Print_' + uniqueName.getTime();

        var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
        prtWindow.document.write('<html><head></head>');
        prtWindow.document.write('<body style="background:none !important">');
        prtWindow.document.write(gridData.outerHTML);
        prtWindow.document.write('</body></html>');
        prtWindow.document.close();
        prtWindow.focus();

    }
</script>
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
<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
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

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css"  />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    
  <script type="text/javascript">
      function myFunction() {
          window.open(".../Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
      }

      function EnableButton() {

          if (document.getElementById("chk").checked == true) {
             // alert(document.getElementById("chk").checked);
              document.getElementById("btnadd").disabled = false;
          }
          else {
             // alert(document.getElementById("chk").checked);
              document.getElementById("btnadd").disabled = true;
          }
      }

     
</script>
<style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
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
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>
</head> 
<body style="">

  <usc:Header ID="Header" runat="server" />   
 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
<form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" EnableViewState="true" UpdateMode="Conditional">
    <ContentTemplate>                
   


      
                        
                    
                            <div class="row">
                               
                                     <div class="form-group" style="text-align:center;margin-top:00px">
                                            <h2>Blaack Forest</h2><br />
                                           <h4>Daily order Form </h4>
                                           
                                           
                                        </div>	    
                                       
                               
                                                                           
										
                                   
                             
                             
                               
                               
                             <div class="table-responsive">
                             <table  class="table table-bordered">  
                             <tr>
                            <td>
                             <asp:Label runat="server" ID="Label1"  >Production Name </asp:Label>
                                <asp:DropDownList runat="server" ID="ddlvendor" class="form-control" Width="200px" AutoPostBack="true" onselectedindexchanged="ddlvendor_SelectedIndexChanged" 
                                                >
                                           
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" Width="200px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                            </td>
                             <td align="center">
                            <label>Order By</label><asp:TextBox ID="txtOrderBy" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                          <asp:Label ID="lblNameerror" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                            <asp:Label runat="server" ID="Label3"  >Req No. </asp:Label>
                             <asp:TextBox ID="txtpono" CssClass="form-control" Width="100px" runat="server" Enabled="false" ></asp:TextBox>
                     
                            </td>
                            <td>
                               <asp:Label runat="server" ID="Label4"  > Req Date</asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtpodate" Width="100px" runat="server" Text="--Select Date--"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1" ControlToValidate="txtpodate" style="color:Red" ErrorMessage="Enter PO Date"></asp:RequiredFieldValidator><br />
                              
                            </td>
                            </tr>
                            
                            </table>
                          
                               
                                
                                 
                             
                               
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               
                               
                                 
                                
                               
                          
                            
                              
                                </div>
                                </div>
                               
                        </ContentTemplate>
                        <Triggers  >
                        <asp:AsyncPostBackTrigger ControlID="ddlvendor" />
                        </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="update" runat="server" ChildrenAsTriggers="true" EnableViewState="true" UpdateMode="Conditional">
                        <ContentTemplate>
                         
                        <div id="horizontalTab" style="">
                       
        <ul>
            <li><a href="#tab-1" >Gateaux</a></li>              
                        <li><a href="#tab-2">Snacks</a></li>
            <li><a href="#tab-3">Puddings</a></li>
            <li><a href="#tab-4">Beverages</a></li>
            <li><a href="#tab-5">Sweets</a></li>
             <li><a href="#tab-6">Party Items</a></li>
            <li><a href="#tab-7">Mousse</a></li>
             <li><a href="#tab-8">Cookies</a></li>
              <li><a href="#tab-9">Cheese cake</a></li>
               <li><a href="#tab-10">Stores</a></li>
               <li><a href="#tab-11">Birthday Cakes</a></li>
               <li><a href="#tab-12">Breads</a></li>
               <li><a href="#tab-13">Sponges</a></li>
                <li><a href="#tab-14">Eggless Cakes</a></li>
          

        </ul>
        
        <div id="tab-1" style="">
       <table class="table table-striped table-bordered table-hover" style="">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvGateaux" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvGateaux_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
             
        </div>
        <div id="tab-2" style="" >
            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvSnacks" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvSnacks_RowDataBound" >
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
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />           
                                </asp:GridView>
                                </td>
                                </tr>
                            
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-3" style="">
           <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvPuddings" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvPuddings_RowDataBound" >
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
                                </td>
                                </tr>
                               
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-4" style="">
            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style=""> 
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvBeverages" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvBeverages_RowDataBound" >
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
                                </td>
                                </tr>
                              
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-5" style="">
           <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvSweets" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvSweets_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-6" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvcandles" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvcandles_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-7" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvMousse" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvMousse_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-8" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvCookies" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvCookies_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-9" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvcheese" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvcheese_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-10" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvStores" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvStores_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-11" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvBday" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvBday_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-12" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvbread" runat="server"  AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" onrowdatabound="gvbread_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-13" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvSponges" runat="server"  AutoGenerateColumns="false" 
                                         BackColor="#99cc99"    Font-Names="Comic Sans MS" RowStyle-BorderStyle="Double" HeaderStyle-HorizontalAlign="Center"  onrowdatabound="gvSponges_RowDataBound" >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>
        <div id="tab-14" style="">
        <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                  <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td style="">
                                <asp:GridView id="gvEggless" runat="server"  AutoGenerateColumns="false" 
                                         BackColor="#99cc99"    Font-Names="Comic Sans MS" 
                                        RowStyle-BorderStyle="Double" HeaderStyle-HorizontalAlign="Center" 
                                        onrowdatabound="gvEggless_RowDataBound"   >
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
                                </td>
                                </tr>
                             
                                </table>
                                </td>
                                </tr>
                                </table>
        </div>

        
        <div  class="form-group" align="center">
                            <asp:CheckBox ID="chk" runat="server" 
                                Text="Please Confirm Selected all the items"  OnClick="EnableButton();" 
                               />
                              <asp:Label ID="lblError" runat="server" style="color:Red"></asp:Label>
                                

									<asp:Button    ID="btnadd" Text="Save" runat="server"  Height="50px" class="btn btn-success"  Enabled="false"
                                         ValidationGroup="val1"   onclick="btnadd_Click" OnClientClick="showProgress()"  />
             <asp:Button ID="btnPreview" runat="server"  CssClass="btn" Visible="false"
                                        Text="preview" onclick="btnPreview_Click" />
                                        
                                        
                                         
                                        
                            </div>
                              <div id="dialog" style="display:none">
     
          <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%"  CssClass="myGridStyle"
    >
        </asp:GridView>
       
    
      
    </div>
                           <!-- <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
    <ProgressTemplate>
        <div id="overlay">
            <div id="modalprogress">
                <div id="theprogress">
                    <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/Preloader_10.gif" />
                    Please wait...
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress> -->

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
                        
                        <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="chk" />
                        </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
<%--<div class="overlay">
<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
<img alt="" src="../images/Preloader_10.gif" />
</div>
</div>--%>
 <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999;  opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif" AlternateText="Loading Please Wait ..." ToolTip="Loading Please Wait ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
</ProgressTemplate>
</asp:UpdateProgress>
                        <!-- /.panel-body -->
           
                    <!-- /.panel -->
               
                <!-- /.col-lg-12 -->
           

 </form>

 
</body>

</html>
