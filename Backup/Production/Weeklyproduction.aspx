<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weeklyproduction.aspx.cs" Inherits="Billing.Production.Weeklyproduction" %>

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
  
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style2.css" rel="stylesheet" type="text/css" />
   
    
    
  

   
   
  
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
    <script src="js/jquery-2.1.0.min.js" type="text/javascript"></script>
   
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
   
                     
                               
                                
                                 
                             
                               
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               
                               
                                 
                                
                               
                          
                            
                              
                     
                         
                        <div id="horizontalTab" style="">
                       
       <ul >
                    <li id="ingrid1" runat="server" style="color:#f7f3e6;background-color:#f7f3e6;color:#f7f3e6"><a href="#tab-0"></a></li>
            
            <li style="color:Black"><a href="#tab-1">Mixer</a></li>
            <li><a href="#tab-2">Table</a></li>
            <li><a href="#tab-3">Oven</a></li>
            <li><a href="#tab-4">Receipts</a></li>
    
        </ul>
    
        <div id="tab-0" style="">
       <div class="row" style="margin-top:20px;margin-left:50px" >
    <legend>Production Editor</legend>

 
   <div class="panel panel-body"  style="background-color:#d6ecf7">
                           <label>Mixer</label><br />
                         
                     <a id="A1" href="Weeklyproduction.aspx#tab-1" runat="server">Enter Section</a>
                        </div>
                         <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Table</label><br />
                        <a id="A2" href="Weeklyproduction.aspx#tab-2" runat="server">Enter Section</a>
                        </div>
                         <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Oven</label><br />
                         <a id="A3" href="Weeklyproduction.aspx#tab-3" runat="server">Enter Section</a>
                        </div>
                        <div class="panel panel-body" style="background-color:#d6ecf7">
                           <label>Receipts</label><br />
                        <a id="A4" href="Weeklyproduction.aspx#tab-4" runat="server">Enter Section</a>
                        </div>

   
    
   </div>
    </div>
        
        <div id="tab-1" style="">
       <div class="form-group">
               <legend style="text-align:left">Mixer</legend>
                <div class="table-responsive " ></div>
    <table  style="border-color:#f7f3e6;width:auto">
    <tr>
     <th >Ingredient Name</th>
      <th>Suppliername Name</th>
       <th> Cost /kilo</th>
        <th>Kilos pr. bag/box</th>
        <th></th>
    
    </tr>
    <tr>
    <td>
    <asp:TextBox id="TextBox10" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="TextBox11" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
   <asp:TextBox id="TextBox12" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox13" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:Button ID="Button5" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
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
         
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   </tbody>
    </table>

               </div>
             
        </div>
        <div id="tab-2" style="" >
            <div class="container">
             
                    <div class=" form-group"  >
                     <%--   <script type="text/javascript" src="jscolor.js"></script>--%>
                        <legend style="text-align:left">Table Week50</legend>
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
    <asp:TextBox id="TextBox14" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="TextBox15" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
   
  
    <td>
    <asp:Button ID="Button6" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
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
<%--
               <div class="col-lg-12" align="center" >
                                    
                                            

            
</div>--%>
               </div>
                     
                    </div>
               
            
        </div>
        </div>
        <div id="tab-3" style="">
           <div class="container">
             <div class="form-group">
               <legend style="text-align:left">Oven Week50</legend>
              
             
                <div class="table-responsive " ></div>
    <table style="border-color:#f7f3e6;width:auto">
    <tr>
     

    
    </tr>
    <tr>
    <td >
    <asp:TextBox id="TextBox16" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="TextBox17" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
   <asp:TextBox id="TextBox18" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox19" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox20" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:TextBox id="TextBox21" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
    <td>
    <asp:Button ID="Button7" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
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
   

<%--
               <div class="col-lg-12" align="center" >
                                    
                                            

            
</div>--%>
               </div></div>
        </div>
        <div id="tab-4" style="">
            <div class="container">
             <div class="form-group">
               <legend style="text-align:left">Receipts</legend>
              
             
                <div class="table-responsive " ></div>
    <table style="border-color:#f7f3e6;width:auto">
    <tr>
     <th >Email </th>
      <th>Print</th>
       <th>Type </th>
        <th>Name </th>
          <th>View </th>
       
    
    </tr>
    <tr>
  
    </tr>
   <tbody>
     <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
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
   

<%--
               <div class="col-lg-12" align="center" >
                                    
                                            

            
</div>--%>
               </div></div>
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
                       
                   
                        <!-- /.panel-body -->
           
                    <!-- /.panel -->
               
                <!-- /.col-lg-12 -->
           

 </form>

 
</body>

</html>