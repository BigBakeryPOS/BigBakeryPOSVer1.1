<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="Billing.Production.Response" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" >
<script language="javascript" type="text/javascript">

    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else

            event.returnValue = false;
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

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>PO Form</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style2.css" rel="stylesheet" type="text/css" />
    <link href="../Accountsbootstrap/css/mGrid.css" rel="stylesheet" type="text/css" />
    
    
  

    <!-- Custom CSS -->
   
  
    <link href="Styles/sb-admin-2.css" rel="stylesheet" type="text/css" />
    <link href="Script/Plugins/metisMenu/metisMenu.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom Fonts -->
    <link href="Styles/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style5.css" rel="stylesheet" type="text/css" />
   

    <link href="Styles/style5.css" rel="stylesheet" type="text/css" />
    
    <link href="Styles/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <script src="Script/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="Script/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="Script/jquery-2.1.0.min.js" type="text/javascript"></script>
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
   
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
  <script type="text/javascript">
      function myFunction() {
          window.open("http://localhost:57111/Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
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
     panel:hover
    {
        background-color:Gray:
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

<form runat="server" id="form1" method="post">

  <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                     
                               
                                
                                 
                             
                               
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                               <ContentTemplate>
                               
                               <div id="horizontalTab" style="">
                       
       <ul >
          <li id="ingrid1" runat="server" style="color:#f7f3e6;background-color:#f7f3e6;color:#f7f3e6"><a href="#tab-0"></a></li>
    
            <li style="color:White"><a href="#tab-1">Ingredients</a></li>
            <li><a href="#tab-2">Recipe Book</a></li>
            <li><a href="#tab-3">Products</a></li>
            <li><a href="#tab-4">Clients and Shops</a></li>
    
        </ul>
        <div id="tab-0" style="">
       <div class="row" style="margin-top:20px;margin-left:50px" >
    <legend>Production Editor</legend>

 
   <div class="panel panel-body"  style="background-color:#d6ecf7">
                           <label>Ingredients</label><br />
                         
                     <a id="A1" href="Response.aspx#tab-1" runat="server">Enter Section</a>
                        </div>
                         <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Recipe Book</label><br />
                        <a id="A2" href="Response.aspx#tab-2" runat="server">Enter Section</a>
                        </div>
                         <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Products</label><br />
                         <a id="A3" href="Response.aspx#tab-3" runat="server">Enter Section</a>
                        </div>
                        <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Clients and Shops</label><br />
                        <a id="A4" href="Response.aspx#tab-4" runat="server">Enter Section</a>
                        </div>

   
    
   </div>
    </div>
             
       
       
        <div id="tab-1" style="" align="center">
       <div class="form-group">
               <legend style="text-align:left">Ingredients</legend>
                <div class="table-responsive " ></div>
    <table  style="border-color:#f7f3e6;width:100%">
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
    <asp:Button ID="Add1" runat="server"  CssClass="btn btn-success" Text="Add" 
            onclick="Add1_Click"/>
    </td>
    </tr>
    
   </table>
   <table>
   <tr>
    <td>
    <asp:GridView ID="Ingredientdrid" runat="server" style="background-color:#d6ecf7" ShowHeader="false" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#d6ecf7"
                      AllowPaging="True" PageSize="8" 
                      CssClass="mGrid" Width="100%">                  
                                    
                                 <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" 
                                     PreviousPageText="Previous" />   
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
         <Columns>
          <asp:BoundField DataField="IngredientName" />
         <asp:BoundField DataField="SupplierName" />
         <asp:BoundField DataField="Costperkg"/>
         <asp:BoundField DataField="Quantity" />
         
         
                               <asp:TemplateField HeaderText="Edit"    >
     <ItemTemplate>
     <asp:LinkButton ID="btnedit"  ForeColor="White"   CommandName="Edit" runat="server"> <asp:Image ID="imdedit"  ImageUrl="~/images/edit.png" runat="server" /></asp:LinkButton>
    

                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField>
          <asp:TemplateField HeaderText="Delete"   >
     <ItemTemplate  >
    
     <asp:LinkButton ID="btndel"   CommandName="Del" runat="server"> <asp:Image ID="Image1"  ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
     <ajaxToolkit:modalpopupextender   
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="btndel"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btndel" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>
                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField> 
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </td>
    </tr>
   </table>
     
 
    

               </div>
             
        </div>
        <div id="tab-2" style="" >
            <div class=" form-group"  >
                     <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                        <legend style="text-align:left">Recipe Book</legend>
                                <div class="form-group">
              
                <div class="table-responsive " >
    <table  style="border-color:#f7f3e6;width:auto">
    <tr>
     <th >Recipe Name</th>
      <th>Dough/Preperation</th>
      
        <th></th>
    
    </tr>
    <tr>
    <td>
    <asp:TextBox id="txtreceipename" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
    <asp:ListItem Text="Dough" Value="0"></asp:ListItem>
    <asp:ListItem Text="Prepration" Value="1"></asp:ListItem>
    </asp:DropDownList>
    </td>
   
  
    <td>
    <asp:Button ID="Add2" runat="server"  CssClass="btn btn-success" Text="Add" 
            onclick="Add2_Click"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="gvReceipe" runat="server" AutoGenerateColumns="False" 
                      AllowPaging="True" PageSize="8" 
                      CssClass="myGridStyle" onrowcommand="gvReceipe_RowCommand">                  
                                    
                                

         <Columns>
          <asp:BoundField DataField="ReceipeID"  Visible="false"  />
         <asp:BoundField DataField="ReceipeName"   />
         <asp:BoundField DataField="Type"  />
        
         
       <asp:TemplateField HeaderText="Edit"    >
     <ItemTemplate>
     <asp:LinkButton ID="btnedit"  ForeColor="White"  CommandArgument='<%#Eval("ReceipeID") %>'  CommandName="editrow" runat="server"> <asp:Image ID="imdedit"  ImageUrl="~/images/edit.png" runat="server" /></asp:LinkButton>
    

                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField>
          <asp:TemplateField HeaderText="Delete"   >
     <ItemTemplate  >
    
     <asp:LinkButton ID="btndel"   CommandName="Del" CommandArgument='<%#Eval("ReceipeID") %>'  runat="server"> <asp:Image ID="Image1"  ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
     <ajaxToolkit:modalpopupextender   
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="btndel"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btndel" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>
                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField> 
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   </tbody>
    </table>
   
   </div>
                                    <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
               </div>
                     
                    </div>
        </div>
        <div id="tab-3" style="">
         
             <div class="form-group">
               <legend style="text-align:left">Products</legend>
              
             
                <div class="table-responsive " ></div>
    <table style="border-color:#f7f3e6;width:auto">
    <tr>
     <th >Product Name</th>
      <th>Unit Size(kilo)</th>
       <th>Dough Type</th>
        <th>Print/Unit(Rs)</th>
        <th>Baking Temperature</th>
         <th>Baking Time</th>
         <th></th>

    
    </tr>
    <tr>
    <td >
    <asp:TextBox id="TextBox3" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="TextBox4" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
   <asp:TextBox id="TextBox5" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox6" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox7" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox8" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:Button ID="Add3" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
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
   

<%--   <script type="text/javascript" src="jscolor.js"></script>--%>
               </div></div>
     
        <div id="tab-4" style="">
          
             <div class="form-group">
               <legend style="text-align:left">Cliens & Shops</legend>
              
             
                <div class="table-responsive " ></div>
    <table style="border-color:#f7f3e6;width:auto">
    <tr>
     <th > </th>
      <th></th>
       <th> </th>
       
    
    </tr>
    <tr>
    <td >
    <asp:TextBox id="TextBox9" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
  <asp:DropDownList ID="drp" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList>
    </td>
  
    
    <td>
    <asp:Button ID="Add4" runat="server"  CssClass="btn btn-success" Text="Add" 
            onclick="Button4_Click"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
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
   

<%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
               </div>
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

                            <script src="Script/jquery.responsiveTabs.js" type="text/javascript"></script>
                           
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
                               
                               </asp:UpdatePanel>
                               
                                 
                                
                               
                          
                            
                              
                     
                         
                        
                       
                   
                        <!-- /.panel-body -->
           
                    <!-- /.panel -->
               
                <!-- /.col-lg-12 -->
           

 </form>

 
</body>

</html>