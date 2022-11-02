<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRMheader.ascx.cs" Inherits="Billing.HeaderMaster.HRMheader" %>
<html lang="en">

<head id="Head1" runat="server">
    <meta charset='utf-8' />
   <meta http-equiv="X-UA-Compatible" content="IE=edge" />
   <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="../js/jquery-latest.min.js" type="text/javascript"></script>
   <!--<script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>-->
    <link href="../css/test.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/test.js" type="text/javascript"></script>
     
    <link href="../css/New.css" rel="stylesheet" type="text/css" />
 <link rel="Stylesheet" type="text/css" href="../css/date.css" />

</head> 

            
<body >



 
  
       
        <div id='cssmenu'>
          <ul>
         
          <li id="master" class='has-sub' runat="server"  style="color:White" >
            <a  href="" style="color:White" >     
                        
               Master <b></b>
            </a>
            <ul >
             <li id="Comp" runat="server"><a href="../HRM/Employee_details.aspx">New Employee </a></li>
               
            </ul>
         </li>
          <li id="leaveform" runat="server" ><a id="A1"  runat="server" style="color:White" href="~/HRM/Leave_Form.aspx"  >Apply Leave</a></li>
          
          <%--<li><a href="../Accountsbootstrap/categorymaster.aspx">Category Master</a></li>
		  <li><a href="../Accountsbootstrap/Descriptiongrid.aspx">Description Master</a></li>
            <li><a href="../Accountsbootstrap/viewcustomer.aspx">Customer Master</a></li>--%>
            <li id="inventry" runat="server" class='has-sub'  >
            <a  href=""   style="color:White" >     
                        
               Reports <b></b>
            </a>
            <ul >
         <li id="leavereport" runat="server" ><a id="A14"  runat="server" style="color:White" href="~/HRM/Leave_Grid.aspx"  >Leave Report</a></li>
          <li id="Attendence" runat="server" ><a id="A15"  runat="server" style="color:White" href="~/HRM/Lowdurations.aspx"  >Attendence Report</a></li>
           
          
          
                      </ul>
                      </li>
             
           
             
           
            </li>
             
          <!--  <li><a href="../Accountsbootstrap/Pettygrid.aspx">Payment Entry</a></li>-->
           
              <li id="Dash" runat="server"><a href="../HRM/Admin_dashboard.aspx" style="color:White">DashBoard</a></li>
              <li id="billfrom" runat="server" visible="false"><a href="#"  style="color:Silver"  ></a></li>
              <li><a href="../HRM/Attendence.aspx" style="color:White">Attendence</a></li>
			<li><a href="../Accountsbootstrap/Home_Page.aspx" style="color:White">Sign  Out</a></li>
         
                    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="true"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false  "> </asp:Label>
                
                    <asp:Label ID="lblServiceID" style="font-size:larger;color:White" runat="server" CssClass="label"></asp:Label>
                   <a href="../Accountsbootstrap/Home_Page.aspx"> <asp:Image ID="Image2" Width="100px" height="50px"  ImageUrl="~/images/BlackForrest.png" runat="server" /></a>
                  
          </ul>
          
        </div>
    
    
</body>


</html>