<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/HRM/Dashboard.aspx.cs" Inherits="HRM.Dashboard" %>


<%@ Register Src="~/HRM/dash_header.ascx" TagName="menu" TagPrefix="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link id="Link1" rel="stylesheet" runat="server" href="~/css/glyphicons.css" />

    <script src="js/glyphicon1.js" type="text/javascript"></script>
    <script src="js/glyphicon2.js" type="text/javascript"></script>
<link href="css/submenu1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <menu:menu ID="menu" runat="server" />
    <%--<menu:menu ID="menu" runat="server" />--%>
    <%--  Row1--%>
    
  
    <div style="margin-top: 0px">
       
        <%--  Row2--%>
       
        <div class="row" style="padding-left:50px">
           <div style="padding-top: 100px" class="col-lg-12">
    
    </div>
              
                <div class="col-lg-12">
                 <%-- column1--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-hand-up" style="font-size:80px"></i>
                                    
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label Visible="false" ID="lblCampaign" runat="server" Text="0"></asp:Label>
                                       <asp:Label ID="Label7" Text="InTime:" runat="server"></asp:Label>
                            <b><asp:Label ID="Label1" ForeColor="White" Text="" runat="server"></asp:Label></b><br />
                            <asp:Label ID="Label9" Text="Duration:" runat="server"></asp:Label>
                           <b> <asp:Label ID="Label2" ForeColor="White" Text=" " runat="server"></asp:Label></b>
                                    </div>
                                    <div class=""><h3>Check-In/Out</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Attendence.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                   
                    <%-- column2--%>
                    <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-tasks" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="lblSales" runat="server" Visible="false" Text="0"></asp:Label>
                                          <asp:Label ID="Label8" ForeColor="White" Text="Your Pending Task:" runat="server"></asp:Label>
                           <b> <asp:Label ID="lblTask" ForeColor="White" runat="server"></asp:Label></b><br />
                            <asp:Label ID="Label12" ForeColor="#5cb85c" Text="Your Pending Task:"  runat="server"></asp:Label>
                            <asp:Label ID="Label13" ForeColor="#5cb85c"  runat="server"></asp:Label>
                            
                                                                </div>
                                  <div class="" style="color:White"><h3>Task</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="TaskMaster.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#5cb85c">View Details</span>
                                <span class="pull-right" style="color:#5cb85c"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#5cb85c"></div>
                            </div>
                        </a>
                    </div>
                </div>
                
                    <%-- column3--%>
                    <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#f0ad4e">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-bed" style="font-size:80px;color:White"></i>
                            
                                </div>
                               
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                  
                                    <asp:Label ID="Label14" runat="server" Visible="false" Text="0"></asp:Label>
                                        <b> <asp:Label ID="Label10" ForeColor="White"  runat="server"></asp:Label></b> 
                                         <br />
                          <b> <asp:Label ID="lbllvappdate" ForeColor="White"  runat="server"></asp:Label><br />
                            <asp:Label ID="lbllvstatus" ForeColor="White"  runat="server"></asp:Label>
                         <asp:Label ID="Label5" ForeColor="White" runat="server"></asp:Label>
                                                             </div>
                                  <div class="" style="color:White">   <h3>Leave Applied</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Leave_Grid.aspx">
                            <div class="panel-footer">                              
                                <%--<span class="pull-left" style="color:#f0ad4e">View Details</span>--%>
                                 <span class="pull-left" style="color:#f0ad4e"> <marquee direction="left" onmouseover="this.stop();" onmouseout="this.start();" scrolldelay="100" scrollamount="2" loop="true" height="50%"
                width="100%">
               
  <b>  <asp:Label ID="lblleave" runat="server" ForeColor="#f0ad4e"></asp:Label></b>
   <asp:TextBox ID="txtmsg" Height="50px" CssClass="form-control" TextMode="MultiLine" ForeColor="Red" Visible="false"
                        runat="server"></asp:TextBox></marquee></span>
                               <%-- <span class="pull-right" style="color:#f0ad4e"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>--%>
                                <div class="clearfix" style="color:#f0ad4e"></div>
                            </div>
                        </a>
                    </div>
                </div>
      
                </div>
            
        </div>
        <div class="row" style="padding-left:50px">
          
                
                <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-user" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">  <asp:Label ID="Email_ID1" ForeColor="White" Text=" EmailID:" runat="server"></asp:Label>
                            <b><asp:Label ID="Email_ID" ForeColor="White" Text=" Email_ID:" runat="server"></asp:Label></b><br />
                            <asp:Label ID="Label4" Text="Contact No:" ForeColor="White"  runat="server"></asp:Label>
                         <b> <asp:Label ID="Contact_No" ForeColor="White" Text=" Contact_No" runat="server"> </asp:Label></b> 
                                                                </div>
                                  <div class="" style="color:White"><h3>Employee
                                Profile </h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="EmployeeProfilegrid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#d8514d">View Details</span>
                                <span class="pull-right" style="color:#d8514d"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#d8514d"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#52b5d2">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-envelope" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"> <asp:Label ID="Label11" ForeColor="White" Text="Current Salary: " runat="server"></asp:Label>
                                  <b> <asp:Label ID="lblsalary" ForeColor="White" runat="server"></asp:Label></b> <br />
                                   <asp:Label ID="Label15" ForeColor="#52b5d2"  Text="Click to Get Your PaySlip" runat="server"></asp:Label>
                                                                </div>
                                  <div class="" style="color:White"><h3>Payslip </h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Current_Salary.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#52b5d2">View Details</span>
                                <span class="pull-right" style="color:#52b5d2"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#52b5d2"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-bullhorn" style="font-size:80px;color:White;"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><marquee onmouseover="this.stop();" onmouseout="this.start();" direction="left" scrolldelay="150" scrollamount="2" loop="true" height="100%"
                                width="100%">
                            <asp:Label ID="Label6" ForeColor="White" Text="  " runat="server"></asp:Label><br />
                         
                            </marquee>
                                                                </div>
                                  <div class="" style="color:White"><h3>Admin Message</h3></div>
                                  <br />
                                </div>

                            </div>
                        </div>
                       
                         
                      
                    </div>
                </div>
           
                </div>
           
        </div>
        <div class="row" style="padding-left:50px">
           
              
                <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#f0ad4e">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-calendar" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="Label3" runat="server" Visible="false" Text="0"></asp:Label>
                                         <asp:Label ID="Label16" ForeColor="White" Text="No of Open Issue: " runat="server"></asp:Label></b> 
                          <b> <asp:Label ID="Label17" ForeColor="White"  runat="server"></asp:Label><br />
                           <b>  <asp:Label ID="Label19" ForeColor="White" Text="Today's
                            Issue: " runat="server"></asp:Label>
                            <asp:Label ID="Label18" ForeColor="White"  runat="server"></asp:Label></b>
                         
                                                                </div>
                                  <div class="" style="color:White"><h3>Issue Tracker</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="Issue_Grid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#f0ad4e">View Details</span>
                                <span class="pull-right" style="color:#f0ad4e"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#f0ad4e"></div>
                            </div>
                        </a>
                    </div>
                </div>
                  <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-gift" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right" >
                                    <div class="huge" >  
                      <b><asp:Label ID="lbbirthday" ForeColor="White" style="color:#ffffff" Text="No Birthdays Notified Till Now" runat="server"></asp:Label></b>
                          <asp:Label ID="Label20" Text="Contact No:" ForeColor="#d8514d"  runat="server"></asp:Label>
                      
                            <asp:Label ID="Label22" Text="Contact No:" ForeColor="#d8514d"  runat="server"></asp:Label>
                         <b> <asp:Label ID="Label23" ForeColor="#d8514d" Text=" Contact_No" runat="server"> </asp:Label></b> 
                                                                </div>
                                  <div class="" style="color:White"><h3>Birthday Notification</h3></div>
                                </div>
                            </div>
                        </div>
                      
                            <div class="panel-footer">
                               <br />
                            </div>
                       
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color:#52b5d2">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                 <i class=" text-center glyphicon glyphicon-comment" style="font-size:80px;color:White"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">  <asp:Label ID="Labelmsg" Text="Message" ForeColor="White" runat="server"></asp:Label>
                                  <b> <asp:Label ID="Label24" ForeColor="#52b5d2" runat="server"></asp:Label></b> <br />
                                   <asp:Label ID="Label25" ForeColor="#52b5d2"  Text="Click to Get Your PaySlip" runat="server"></asp:Label>
                                                                </div>
                                  <div class="" style="color:White"><h3>Comments</h3></div>
                                </div>
                            </div>
                        </div>
                        <a href="EmployeeMsgGrid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left" style="color:#52b5d2">View Details</span>
                                <span class="pull-right" style="color:#52b5d2"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                                <div class="clearfix" style="color:#52b5d2"></div>
                            </div>
                        </a>
                    </div>
                </div>
             
                </div>
                 
          
        </div>
        
    </div>
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
