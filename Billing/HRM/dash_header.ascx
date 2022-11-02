<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dash_header.ascx.cs"
    Inherits="HRM.dash_header" %>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Category Master - bootsrap</title>
    <link id="Link1" rel="stylesheet" runat="server" href="~/css/glyphicons.css" />
    <script src="../js/glyphicon1.js" type="text/javascript"></script>
    <script src="../js/glyphicon2.js" type="text/javascript"></script>
    <link href="../css/submenu1.css" rel="stylesheet" type="text/css" />
    <link href="../images/logo1.png" type="image/x-icon" rel="Shortcut Icon" />
    <link href="../css/submenu1.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>
    <!-- Bootstrap Core CSS -->
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<%--<style>
    @media (min-width: 768px)
    {
        .navbar-collapse
        {
            height: auto;
            border-top: 0;
            box-shadow: none;
            max-height: none;
            padding-left: 0;
            padding-right: 0;
        }
        .navbar-collapse.collapse
        {
            display: block !important;
            width: auto !important;
            padding-bottom: 0;
            overflow: visible !important;
        }
        .navbar-collapse.in
        {
            overflow-x: visible;
        }
    
        .navbar
        {
            max-width: 155px;
            margin-right: 0;
            margin-left: 0;
            height: 1350px;
        }
    
        .navbar-nav, .navbar-nav > li, .navbar-left, .navbar-right, .navbar-header
        {
            float: none !important;
        }
    
        .navbar-right .dropdown-menu
        {
            left: 0;
            right: auto;
        }
        .navbar-collapse .navbar-nav.navbar-right:last-child
        {
            margin-right: 0;
        }
    }
</style>--%>
<body >

  <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>              
                
            </div>
            <div class="row">
            <div class="col-lg-2" ></div>
            <div class="col-lg-7" style="padding-left:0px"><a class="navbar-brand pull-left" href="Admin_dashboard.aspx"><asp:Image ID="Image2" runat="server" ImageUrl="s"  /></a></div>
              <div class="col-lg-2">
              <br />  <br />
           
            </div>
          
            </div>
    <div >
        <nav class="navbar navbar-default navbar-fixed-top" style="background-color:Black"  role="navigation">
      <div class="container-fluid" id="bgmenu" runat="server" > 
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
             
          </button>
            <asp:Image ID="Image3" ImageUrl="~/images/logo11.png" Height="60px"  runat="server"></asp:Image>
       <%--   <asp:Image ID="Image1" runat="server"></asp:Image>--%>
          
         <%-- <a href="Attendance_Grid.aspx"><img src="../images/logo11.png" alt="logo"/></a>--%>
        </div>
               
        <div id="navbar" class="navbar-collapse collapse">
        <a class="navbar-brand pull-left" href="Dashboard.aspx"><asp:Image ID="Image1" Width="100px" Visible="false" runat="server" ></asp:Image></a>
        <a class="navbar-brand pull-left" href="Dashboard.aspx"><asp:Image ID="Image5" runat="server" ImageUrl="" Visible="false" Width="65%" /><asp:Label runat="server" ID="lblWelcome" ForeColor="White"  CssClass="label" style="font-size:medium" >Welcome : </asp:Label>              
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  style="font-size:medium" Visible="true"> </asp:Label></a>
         
          <ul class="nav navbar-nav navbar-right">
          <li id="Li21" runat="server"><a href="Admin_dashboard.aspx"  style="color:White">Dashboard</a></li>
             
             <li class="dropdown" id="DdMenu1" runat="server">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" id="menu1"  style="color:White;background-color:Black">
               Master <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
                <li id="m2" runat="server"><a href="Employee_details.aspx" style="color:Black">New Person </a></li>
            
               
                <%--<li id="c3" runat="server"><a href="Issue_Tracker.aspx">Issue Tracker</a></li>  --%>  
                                                    
            </ul>
         </li>
          
        
            
              <li id="Li3"  runat="server"><a href="Leave_Form.aspx"  style="color:White">Apply Leave</a></li>
       
               
                       
                  <li id="leavereport"  runat="server"><a href="Leave_Grid.aspx"  style="color:White">leave Report</a></li> 
         <li class="dropdown" id="DdMenu2" runat="server" >
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" id="menu2" style="color:White; background-color:Black" >
               Reports  <b class="caret"></b>
            </a>
            <ul class="dropdown-menu"  style="color:Black">
            <%--<---------test--------------->--%>
              
                 <%-- <---------test--------------->--%>
                 
             
             <%--<li id="Li19" runat="server"><a href="EmployeeMsgGrid.aspx">EmployeeMsgGrid</a></li>--%>
        
            
           
               <li id="Li1"  runat="server"><a href="Leave_Grid.aspx"  style="color:Black">leave Report</a></li>
                
                   <li id="Li12"  runat="server"><a href="Lowdurations.aspx"  style="color:Black">Attendence Grid</a></li>
                  <li id="mon_leave"  runat="server"><a href="Monthwise_Leave.aspx" style="color:Black">Monthly Report</a></li>
                 
   
   



              <%--  
                <li id="leave" class="dropdown dropdown-submenu"><a href="#" class="dropdown-toggle" data-toggle="dropdown" runat="server">Leave Report</a>
                <ul class="dropdown-menu" >
            
                  <li id="Li12"  runat="server"><a href="Lowdurations.aspx">Durations&Leave datails</a></li>
                  <li id="mon_leave"  runat="server"><a href="Monthwise_Leave.aspx">Monthly Report</a></li>
                  <li id="Li15"  runat="server"><a href=" Current_Salary.aspx"> Current Salary</a></li>
                  <li id="Li16" runat="server"><a href="salaryallowances.aspx"> Salary Allowances</a></li>
                  
                  <li id="salslip" runat="server"><a href="Salaryslip1.aspx">Salray slip </a></li>
                  </ul>
                        </li>--%>

        
             
               <%--<li id="Li1" runat="server"><a href="Attendance_Grid.aspx">Today's Attendance</a></li>--%>
               <li id="m1" runat="server"><a href="Emp_gird.aspx"  style="color:Black">Person Details</a></li>
               


                        </ul>
                  </li>
          
        
           <%-- <li class="dropdown" id="Li13" runat="server" >
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" id="A1" style="color:White"  >
               Payroll  <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
            <li id="Li14" runat="server"><a href="Salary_Calculate.aspx">Salary Details</a></li>
            </ul>
         </li>--%>
          <%--<li><a href="../Accountsbootstrap/categorymaster.aspx">Category Master</a></li>
		  <li><a href="../Accountsbootstrap/Descriptiongrid.aspx">Description Master</a></li>
            <li><a href="../Accountsbootstrap/viewcustomer.aspx">Customer Master</a></li>--%>
           <li id="m5" runat="server"><a href="Attendence.aspx" style="color:White">Attendance</a></li>
           
            <li><a href="../Accountsbootstrap/Home_Page.aspx" style="color:White">Logout</a></li>
          

            

        
                   <%-- <asp:Label runat="server" ID="lblWelcome" ForeColor="White"  CssClass="label" style="font-size:medium" >Welcome : </asp:Label><br />
                    <br />
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  style="font-size:medium" Visible="true"> </asp:Label>--%>
                    <asp:Label runat="server" ID="lblUserID"  CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="ddldesignation" ForeColor="White" CssClass="label" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblServiceID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label ID="lblscreenname" style="font-size:large;color:White" runat="server" CssClass="label"></asp:Label>
      </ul>
         
      </div>
</nav>
    </div>
    <!-- /#page-wrapper -->
    <!-- jQuery -->
    <script type="text/javascript" src="../js/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script type="text/javascript" src="../js/plugins/metisMenu/metisMenu.min.js"></script>
    <!-- Custom Theme JavaScript -->
    <script type="text/javascript" src="../js/sb-admin-2.js"></script>
</body>
</html>
