<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/HRM/Admin_dashboard.aspx.cs"
    Inherits="HRM.Admin_dashboard" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link rel="stylesheet" href="~/css/glyphicons.css" />

    <script src="../js/glyphicon1.js" type="text/javascript"></script>
    <script src="../js/glyphicon2.js" type="text/javascript"></script>
<link href="../css/submenu1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <menu:menu ID="menu" runat="server" />

      <div class="row" style="padding-left:0px">
           <div style="padding-top: 100px" class="col-lg-12">
    
    </div>
        <div class="col-lg-12">
            <div class="col-lg-2">
            </div>
            <div class="col-lg-12  ">
            
                <%-- column1--%>
                <div class="col-lg-3 col-md-6" style="display:none">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-tasks" style="font-size:80px"></i>
                                    
                                </div>
                                <div class="col-xs-9 text-right" style="display:none">
                                    <div class="huge"> 
                                   
                  
                                  <label style="font-weight:bold;color:#ffffff" >Task Pending: 
                                   <asp:Label ID="lblTask" style="font-weight:bold" runat="server"></asp:Label></label>
                                         <label style="font-weight:bold;color:#ffffff" >Task Completed:               
                                         <asp:Label ID="ibltaskcomp" style="font-weight:bold" runat="server"></asp:Label> </label>

                  
                                    </div>
                                    <div class=""><h3>Task</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="taskGrid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
              
                <%-- column2--%>
                <div class="col-lg-3 col-md-6" style="display:none">
                    <div class="panel" style="background-color:#5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-calendar" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                    <label style="font-weight:bold;color:#ffffff" >No of Issue:
                           <asp:Label ID="Label8" style="font-weight:bold;color:#ffffff"   Text="No of Issue:" runat="server"></asp:Label></label>
                                <label style="font-weight:bold;color:#ffffff" >ToDay Issue:
                            <asp:Label ID="Label12" style="font-weight:bold;color:#ffffff" Text="ToDay Issue:"  runat="server"></asp:Label></label>
                                                                </div>
                                  <div class="" style="color:White"><h3>Issue Tracker</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Issue_Grid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#5cb85c">View Details</span>
                                <span class="pull-right" style="color:#5cb85c"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#5cb85c"></div>
                            </div>
                        </a>
                    </div>
                </div>
                
                <%-- column3--%>
                <div class="col-lg-3 col-md-6">
                    <div class="panel" style="background-color:#f0ad4e">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-bed" style="font-size:80px;color:White"></i>
                            
                                </div>
                               
                                <div class="col-xs-9 text-right" >
                                    <div class="huge">
                                    <label style="font-weight:bold;color:#ffffff" >Today Leave Applied:
                                  <asp:Label ID="lvtoday" style="font-weight:bold"  ForeColor="White"  runat="server"></asp:Label>  </label> 
                                        <label style="font-weight:bold;color:#ffffff" >                                  
                         <asp:Label ID="lbllvappdate" ForeColor="#f0ad4e" Text="Leave Applied Date:" runat="server"></asp:Label></label>
                         
                      
                                                             </div>
                                  <div class="" style="color:White">   <h3>Leave Applied</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Leave_Grid.aspx">
                            <div class="panel-footer">                              
                                <span class="pull-left" style="color:#f0ad4e">View Details</span>
                               
                                <span class="pull-right" style="color:#f0ad4e"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#f0ad4e"></div>
                            </div>
                        </a>
                    </div>
                </div>
        <div class="col-lg-3 col-md-6" style="display:none">
                    <div class="panel" style="background-color:#d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-user" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right" style="display:none">
                                <div class="huge">
                                 <label style="font-weight:bold;color:#ffffff" >EmailID:
                                    <b>  <asp:Label ID="Email_ID" ForeColor="#d8514d"  runat="server"></asp:Label></b>
                                    </label>
                   
                     
                         
                                                                </div>
                                  <div class="" style="color:White"><h3>Current Salary Details</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Current_Salary.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#d8514d">View Details</span>
                                <span class="pull-right" style="color:#d8514d"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#d8514d"></div>
                            </div>
                        </a>
                    </div>
                </div>
           
             
            </div>
        </div>
    </div>
    <br />
    <br />
     <div class="col-lg-12  ">
    <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#337ab7">
                        <div class="panel-heading">
                            <div class="row">
                                
                                <div class="col-xs-12" >                               
                                    <div class="col-xs-3" > <i class=" text-center glyphicon glyphicon-bed" style="font-size:50px;color:White"></i></div>
                                 <div class="col-xs-9" style="color:White"><h3>Pending Leave</h3></div>
                                    <div class="huge" style="height:200px"> 
                             <marquee direction="up" scrolldelay="100" scrollamount="2" onmouseover="this.stop();" onmouseout="this.start();" loop="true" height="75%"
                width="100%" bgcolor="#337ab7">
               
   <asp:Label ID="lblleave" runat="server" ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtmsg" Height="100px" CssClass="form-control" TextMode="MultiLine" ForeColor="Red" Visible="false"
                        runat="server"></asp:TextBox></marquee>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
    <div class="col-lg-4 col-md-6" style="display:none">
                    <div class="panel" style="background-color:#d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                
                                <div class="col-xs-12" >                               
                                    <div class="col-xs-3" > <i class=" text-center glyphicon glyphicon-tasks" style="font-size:50px;color:White"></i></div>
                                 <div class="col-xs-9" style="color:White"><h3>  Task Status</h3></div>
                                    <div class="huge" style="height:200px"> 
                               <marquee direction="up" scrolldelay="150" onmouseover="this.stop();" onmouseout="this.start();" scrollamount="2" loop="true" height="75%"
                width="100%" style="background-color:#d8514d">
               
   <asp:Label ID="lbltaskstatus" runat="server" ForeColor="White"></asp:Label>
    <asp:TextBox ID="txttaskmsg" Height="100px" CssClass="form-control" TextMode="MultiLine" ForeColor="Red" Visible="false"
                        runat="server"></asp:TextBox></marquee>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                
                                <div class="col-xs-12" >                               
                                    <div class="col-xs-3" > <i class=" text-center glyphicon glyphicon-hand-up" style="font-size:50px;color:White"></i></div>
                                 <div class="col-xs-9" style="color:White"><h3> Login Details</h3></div>
                                    <div class="huge" style="height:200px"> 
                              <marquee direction="up" scrolldelay="100" onmouseover="this.stop();" onmouseout="this.start();" scrollamount="2" loop="true" height="75%"
                width="100%" style="background-color:#5cb85c">
   <asp:Label ID="lbllogin" runat="server" ForeColor="White"></asp:Label></marquee>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                </div>

     
<%--   <div style="padding-left:175px" class="col-lg-5">
   <div class="col-lg-4 col-md-6">
                    <div class="panel">
                        <div class="panel-heading">
                            <div class="row">
                                
                                <div class="col-xs-12" >                               
                                  <%--  <div class="col-xs-3" > <i class=" text-center glyphicon glyphicon-hand-up" style="font-size:50px;color:White"></i></div>
                                 <div class="col-xs-9" style="color:White"><h3> Attendace Chart</h3></div>--%>
                                  <%--  <div class="huge" style="background-color:White"> 
                              <asp:Chart ID="Chart1" runat="server" Width="500px" Height="300px" BackColor="#f0ad4e" >
 <Titles>
        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)" 
            Text="Attendance Chart(Year)">
        </asp:Title>
    </Titles>
<Series>
  <asp:Series Name="Series1" Color="CadetBlue" Font="Times New Roman, 20pt, style=Bold" IsValueShownAsLabel="true"   IsVisibleInLegend="false" LegendText="Overall"  >
 </asp:Series>
</Series>
<Legends >
    <asp:Legend Name="Admin"></asp:Legend>
    </Legends>
     <chartareas>
        <asp:ChartArea    Name="ChartArea1">
      <AxisX   Interval="1"   IntervalType="Number"  ArrowStyle="Triangle" ><MajorGrid LineWidth="0" /> <MinorGrid /></AxisX>
  <AxisY   IsStartedFromZero="true"  IsLabelAutoFit="true" ArrowStyle="Triangle" ><MajorGrid LineWidth="0" /> </AxisY>
       
        </asp:ChartArea>
        
    </chartareas>

</asp:Chart>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
    
</div>--%>
<%--<div class="col-lg-5" style="padding-left:175px">
 <asp:Chart ID="Chart2" runat="server" Width="500px" Height="300px">
 <Titles>
        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)" 
            Text="Attendance Chart(month)">
        </asp:Title>
    </Titles>
<Series>
  <asp:Series Name="Series1" Color="CadetBlue" Font="Times New Roman, 20pt, style=Bold" IsValueShownAsLabel="true"   IsVisibleInLegend="false" LegendText="Overall"  >
 </asp:Series>
</Series>
<Legends >
    <asp:Legend Name="Admin"></asp:Legend>
    </Legends>
     <chartareas>
        <asp:ChartArea    Name="ChartArea1">
      <AxisX   Interval="1"   IntervalType="Number"  ArrowStyle="Triangle" ><MajorGrid LineWidth="0" /> <MinorGrid /></AxisX>
  <AxisY   IsStartedFromZero="true"  IsLabelAutoFit="true" ArrowStyle="Triangle" ><MajorGrid LineWidth="0" /> </AxisY>
       
        </asp:ChartArea>
        
    </chartareas>

</asp:Chart>
</div>--%>
    <%-- <div class="row pad">
            <div class="col-lg-12">
            </div>
        </div>
        <%--  Row2--%>
    </form>
    <asp:Label ID="lblempid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblempname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbllogintime" runat="server"></asp:Label>
    <asp:Label ID="lbllogtime" runat="server"></asp:Label>
    <asp:Label ID="id" runat="server"></asp:Label>
    <asp:Label ID="lbleid" runat="server"></asp:Label>
    <asp:Label ID="lbllogdate" runat="server"></asp:Label>
    <asp:Label ID="ltime" runat="server"></asp:Label>
    <asp:Label ID="lblattedance" runat="server"></asp:Label>
</body>
</html>
