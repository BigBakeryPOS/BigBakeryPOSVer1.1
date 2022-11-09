<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resposivemenu.aspx.cs" Inherits="Bakery.resposivemenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Fees Registration</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>

    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtFeesname'), "Fees Name")
            {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
	</script>
    <!-- Bootstrap Core CSS -->
  
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- MetisMenu CSS -->
    <link href="Scripts/Plugins/metisMenu/metisMenu.min.css" rel="stylesheet" type="text/css" />
   
    <link href="Styles/sb-admin-2.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
   

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="Scripts/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    
   

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head> 
<body style="background-color:#f7f3e6">


<form id="Form1" runat="server">
    
     
 
 
            <div class="row" >
                <div class="col-lg-12">
                    <h1 id="hd1" runat="server" class="page-header"  style="text-align:center;color:#f7f3e6" ></h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row"></div>
            <div class="col-lg-12">
            <div class="panel panel-default">
            <div class="panel-body">
              <div id="horizontalTab1">
               <ul >
           
            <li><a href="#tab-11">Production Editor</a></li>
            <li><a href="#tab-12">Weekly Production</a></li>
            <li><a href="#tab-13">Daily Feedback</a></li>
            <li><a href="#tab-14">Information & Status</a></li>
    
        </ul>


            <div class="row" id="tab-11" style="background-color: #2ea3ce">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                         

                           <div id="horizontalTab">
                               
               
               
        <ul >
            <li style="color:Black"><a href="#tab-1">Ingredients</a></li>
            <li><a href="#tab-2">Recipe Book</a></li>
            <li><a href="#tab-3">Products</a></li>
            <li><a href="#tab-4">Clients and Shops</a></li>
    
        </ul>
        <div class="row" id="tab-1" style="background-color: White;">
        
            <div class="container" >
            
              <div class="form-group">
               <legend style="text-align:left">Ingredients</legend>
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
    <asp:Button ID="Button1" runat="server"  CssClass="btn btn-success" Text="Add"/>
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
         
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   </tbody>
    </table>

               </div>
                  </div>
                 
                  </div>
        <div class="row" id="tab-2" style="background-color:white;">
            <div class="container">
             
                    <div class=" form-group"  >
                     <%--   <script type="text/javascript" src="jscolor.js"></script>--%>
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
    <asp:TextBox id="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
    
    </td>
    <td>
    <asp:TextBox id="TextBox2" runat="server" CssClass="form-control" ></asp:TextBox>
    </td>
   
  
    <td>
    <asp:Button ID="Button2" runat="server"  CssClass="btn btn-success" Text="Add"/>
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
        <div class="row" id="tab-3" style="background-color:white;">
            <div class="container">
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
    <asp:Button ID="Button3" runat="server"  CssClass="btn btn-success" Text="Add"/>
    </td>
    </tr>
   <tbody>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
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
        <div class="row" id="tab-4" style="background-color:white;">
            <div class="container">
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
    <asp:Button ID="Button4" runat="server"  CssClass="btn btn-success" Text="Add"/>
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
   

<%--
               <div class="col-lg-12" align="center" >
                                    
                                            

            
</div>--%>
               </div></div>
                    </div>
                    </div>
                    </div></div>
              </div>
            </div>
            </div>
            <div class="row" id="tab-12" style="background-color: #2ea3ce">

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                       

                           <div id="horizontalTab2">
                               
               
               
        <ul >
            <li style="color:Black"><a href="#tab-21">Mixer</a></li>
            <li><a href="#tab-22">Table</a></li>
            <li><a href="#tab-23">Oven</a></li>
            <li><a href="#tab-24">Receipts</a></li>
    
        </ul>
        <div class="row" id="tab-21" style="background-color: White;">
        
            <div class="container" >
            
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
         
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   </tbody>
    </table>

               </div>
                  </div>
                 
                  </div>
        <div class="row" id="tab-22" style="background-color:white;">
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
        <div class="row" id="tab-23" style="background-color:white;">
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
        <div class="row" id="tab-24" style="background-color:white;">
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
                    </div>
                    </div></div>
              </div>
            </div>

            </div>
            <div class="row" id="tab-13"  style="background-color: White">
                <div class="row">
      <div class="container" >
            
              
               <legend style="text-align:left">Daily Feedback</legend>
               <div class="col-lg-12">
              <div class="form-group col-lg-4">
 <asp:DropDownList ID="DropDownList1" Width="300px" CssClass="form-control" runat="server"></asp:DropDownList>
 </div>
 <div class="form-group col-lg-4">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:TextBox ID="txtstartdate" Width="300px" CssClass="form-control" runat="server"></asp:TextBox>
                    
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtstartdate"
                        runat="server" Format="dd/MM/yyyy" CssClass="ajax__calendar">
                    </ajaxToolkit:CalendarExtender>
                    </div>
   </div>

     <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                      AllowPaging="True" PageSize="8" 
                      CssClass="myGridStyle">                  
                                    
                                 <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" 
                                     PreviousPageText="Previous" />   
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
         <Columns>
        <asp:BoundField DataField="days" HeaderText="days" SortExpression="days" />


         
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   

               </div>
                  </div>
            </div>
             <div class="row" id="tab-14" style="background-color: #2ea3ce">
            </div>

           
            
            <div></div>
        </div>

        
        <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
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
     <script type="text/javascript">
         $(document).ready(function () {
             var $tabs = $('#horizontalTab1');
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
       <script type="text/javascript">
           $(document).ready(function () {
               var $tabs = $('#horizontalTab2');
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


    <div class="row"  >

                     <div class="col-lg-12" align="center" >
                              
                        <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label>
										<asp:Button ID="btnadd" runat="server" class="btn btn-info" Text="Save" ValidationGroup="val1"  style="width:120px;margin-left:65PX"/>
                                        <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit"   style="width:120px;"/>
                    </div>
                    </div>
                               
                             
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
          
            <!-- /.row -->
       
        <!-- /#page-wrapper -->
		
		
		
		<!-- jQuery -->
   
   </form>
</body>

</html>
