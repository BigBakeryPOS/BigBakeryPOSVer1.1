<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="HRM.Header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Category Master - bootsrap</title>
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <link href="css/submenu1.css" rel="stylesheet" type="text/css" />
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
     @media (min-width: 768px) {
  .navbar-collapse {
    height: auto;
    border-top: 0;
    box-shadow: none;
    max-height: none;
    padding-left:0;
    padding-right:0;
  }
  .navbar-collapse.collapse {
    display: block !important;
    width: auto !important;
    padding-bottom: 0;
    overflow: visible !important;
  }
  .navbar-collapse.in {
    overflow-x: visible;
  }

.navbar
{
	max-width:200px;
	margin-right: 0;
	margin-left: 0;
	height:900px;
	
}	

.navbar-nav,
.navbar-nav > li,
.navbar-left,
.navbar-right,
.navbar-header
{float:none !important;}

.navbar-right .dropdown-menu {left:0;right:auto;}
.navbar-collapse .navbar-nav.navbar-right:last-child {
    margin-right: 0;
}
}
</style>--%>
<body>
    <div style="height:50px">
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation"  >
      <div class="container-fluid" id="bgmenu" runat="server">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
             
          </button>
          <asp:Image ID="Image1" runat="server" Height="60px"></asp:Image>
          
         <%-- <a href="Attendance_Grid.aspx"><img src="../images/logo11.png" alt="logo"/></a>--%>
        </div>
               
        <div id="navbar" class="navbar-collapse collapse">
         <a class="navbar-brand pull-left" href="Dashboard.aspx"><asp:Image ID="Image2" Height="60px" Width="100px" Visible="false" runat="server" ></asp:Image></a>
        <a class="navbar-brand pull-left" href="Dashboard.aspx"><asp:Image ID="Image5" runat="server" ImageUrl="" Visible="false" Height="60px" Width="65%" /><asp:Label runat="server" ID="Label1" ForeColor="White"  CssClass="label" style="font-size:medium" >Welcome : </asp:Label>              
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  style="font-size:medium" Visible="true"> </asp:Label></a>
          <ul class="nav navbar-nav navbar-right">
          <li id="Li21" runat="server"><a href="Admin_dashboard.aspx" style="color:White">Dashboard</a></li>
             
             <li class="dropdown" id="DdMenu1" runat="server">
            <a href="#" class="dropdown-toggle1" data-toggle="dropdown" id="menu1" style="color:White">
               Master <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
                <li id="m2" runat="server"><a href="Employee_details.aspx">New Employee </a></li>
                <li id="m3" runat="server"><a href="Hrm_voucher.aspx">HRM Voucher</a></li>
                <li id="c1" runat="server"><a href="Client_Master.aspx">Client Master</a></li>
                <li id="c2" runat="server"><a href="Project_Master.aspx">Project Master</a></li>
                 <li id="Li9" runat="server"><a href="Message.aspx">Send Message</a></li>
            
                <li id="Task" runat="server"><a href="Todaytasks.aspx">Today task</a></li>
                <li id="T11" runat="server"><a href="TaskMaster.aspx">Task Master</a></li>
                   <li id="Li5" runat="server"><a href="My Doccuments.aspx">UploadDoccument</a></li>
                <li id="Li6" runat="server"><a href="docgrid.aspx">Doccuments</a></li>
                  <li id="Li14" runat="server"><a href="Holidayscalender.aspx"> Holidayscalender</a></li>
                  
                  
                <%--<li id="c3" runat="server"><a href="Issue_Tracker.aspx">Issue Tracker</a></li>  --%> 
                                                    
            </ul>
         </li>
          <li class="dropdown" id="ddmmenu" runat="server">
            <a href="#" class="dropdown-toggle1" data-toggle="dropdown" id="A1" style="color:White">
               Pay Roll <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
                   <li id="Li19"  runat="server"><a href="Salary_Calculate.aspx">Salaryslip Generator</a></li>
                        <li id="Li20"  runat="server"><a href=" Current_Salary.aspx"> Current Salary</a></li>
                                                    
            </ul>
         </li>
         <li id="Li18" runat="server"><a href="Dashboard.aspx" style="color:White">Dashboard</a></li>
            
        <li class="dropdown" id="ddhrm" runat="server">
    <a href="#" class="dropdown-toggle1" data-toggle="dropdown"  style="color:White">HRM Master <b class="caret"></b></a>

    <ul class="dropdown-menu ">
  <li id="Li10" runat="server"><a href="Attendance_Grid.aspx"  >Today's Attendance</a></li>
              <li id="Li25" runat="server"><a href="Todaytasks.aspx">Today task</a></li>
               <li id="Li3"  runat="server"><a href="Leave_Form.aspx">Apply Leave</a></li>
         <%--      <li id="T5" runat="server"><a href="EmployeeSugestion.aspx">Suggestion</a></li>--%>
               <li id="Li11" runat="server"><a href="EMessage.aspx">Message</a></li>  
                    <%--<li id="Li13" runat="server"><a href="Holidayscalender.aspx"> Holidayscalender</a></li>--%>
                     <li id="Li24" runat="server"><a href="Holiday Grid.aspx"> Holidays calender</a></li>
            
                  </ul></li>
               
                       
                  
         <li class="dropdown" id="DdMenu2" runat="server" >
            <a href="#" class="dropdown-toggle1" data-toggle="dropdown" id="menu2" style="color:White"  >
               Reports  <b class="caret"></b>
            </a>
            <ul class="dropdown-menu">
           
                    <li class="dropdown-submenu" id="ddmenupay" runat="server">
    <a tabindex="0" data-toggle="dropdown"  >Payroll</a>

    <ul class="dropdown-menu">
                      <li id="Li17"  runat="server"><a href="Salary_Calculate.aspx">Salaryslip Generator</a></li>
                  </ul></li>
             <li id="Li22" runat="server"><a href="TaskMaster.aspx">Task Report</a></li>
             <li id="T2" runat="server"><a href="Taskgrid.aspx">TodayTasks</a></li>
                  <li id="Li1" runat="server"><a href="Messagegrid.aspx">MessageGrid</a></li>
            
<%--             <li id="T4" runat="server"><a href="Suggrid.aspx">Suggestions</a></li>--%>
             <li id="Li8" runat="server"><a href="Clientgrid.aspx">Appointment Schedule </a></li>
            
                 <li class="dropdown-submenu">
    <a tabindex="0" data-toggle="dropdown">Leave Report</a>

    <ul class="dropdown-menu ">
   <li id="Li12"  runat="server"><a href="Lowdurations.aspx">Durations&Leave datails</a></li>
                  <li id="mon_leave"  runat="server"><a href="Monthwise_Leave.aspx">Monthly Report</a></li>
                  <li id="Li15"  runat="server"><a href=" Current_Salary.aspx"> Current Salary</a></li>
                  <li id="Li16" runat="server" visible="false"><a href="salaryallowances.aspx"> Salary Allowances</a></li>
                  
                  <li id="salslip" runat="server"><a href="Salaryslip1.aspx">Salray slip </a></li>
                  </ul></li>
                 
               <li id="m1" runat="server"><a href="Emp_gird.aspx">Employee Details</a></li>
               <li id="m4" runat="server"><a href="Hrm_vouchergird.aspx">HRM Voucher</a></li>
               <li id="c4" runat="server"><a href="Issue_Grid.aspx">Issues</a></li>   
                <li id="Li2" runat="server"><a href="Client_Grid.aspx">Client Details</a></li>
                <li id="Li4"   runat="server"><a href="Leave_Grid.aspx">LeaveDetails</a></li>
              
                 <li id="Li7"  runat="server"><a href="Appointmentform.aspx">ClientDetails</a></li> 
                 <li id="Li23"  runat="server"><a href="Project_Grid.aspx">ProjectDetails</a></li> 
                    <li id="Li50"  runat="server"><a href="Project_Group.aspx">Project Group</a></li> 
      
                        </ul>
                  </li>
          
        
           
           <li id="m5" runat="server"><a href="Attendence.aspx" style="color:White">Attendance</a></li>
            <li id="config" runat="server"><a href="configuration.aspx" style="color:White">Configuration</a></li>
            <li><a href="Usersettings.aspx" style="color:White">Settings</a></li>
            <li><a href="ChooseLogin.aspx" style="color:White">Logout</a></li>
          

            

        
                  
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="ddldesignation" ForeColor="White" CssClass="label" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblServiceID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label ID="lblscreenname" style="font-size:large;color:White" runat="server" CssClass="label"></asp:Label>
      </ul>
          
        </div>
      </div>
</nav>
    </div>
    <%-- <div >
         <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" style="float:right" href="index.html">SB Admin v2.0</a>
            </div>
            </nav>
            </div>--%>
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
