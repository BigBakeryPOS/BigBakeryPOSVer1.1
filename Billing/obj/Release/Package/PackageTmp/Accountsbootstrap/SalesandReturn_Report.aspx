<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesandReturn_Report.aspx.cs" Inherits="Billing.Accountsbootstrap.SalesandReturn_Report" %>


<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
     <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="../css/font-awesome.css" rel="stylesheet" type="text/css">
    <link href="../css/style.css" rel="stylesheet" type="text/css">
    <link href="../css/Dashboard.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://use.fontawesome.com/07b0ce5d10.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <!-- begin SIDE NAV USER PANEL -->
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Sales and Return Report</h1>
	    </div>
        <div class="panel-body">
  
     
         <div class="col-md-3">
         <br />
         <asp:RadioButton ID="rbsales" runat="server" Text="Sales" OnCheckedChanged="rbsales_CheckedChanged" AutoPostBack="true"  />
         <asp:RadioButton ID="rbstockreturn" runat="server" Text="Stock Return" OnCheckedChanged="rbstockreturn_CheckedChanged" AutoPostBack="true"  />
         </div>
     
     <div class="col-md-3">
     <label>Select Type </label>
      <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlType_Change">
      <asp:ListItem Text="--Select Type--" Selected="True" Value="Select Type"></asp:ListItem>
      <asp:ListItem Text="DayWise" Value="Daywise"></asp:ListItem>
      <asp:ListItem Text="DateWise" Value="Datewise"></asp:ListItem>
      <asp:ListItem Text="WeekWise" Value="Weekwise"></asp:ListItem>
      <asp:ListItem Text="MonthWise" Value="Monthwise"></asp:ListItem>
      </asp:DropDownList>
      </div>

      <div class="col-lg-3" id="divfrm" runat="server" visible="false">
        <label>From date</label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName" class="form-control">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate" AutoPostBack="true" class="form-control">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3" id="divto" runat="server" visible="false">
                                    <label >
                                        To date</label>
                                    <asp:TextBox runat="server" ID="txttodate" class="form-control" >
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                     <div class="col-lg-3" id="divbtn" runat="server" visible="false">
                                     <br />
                                    <asp:Button ID="btnReport" runat="server" Text="Generate Report" CssClass="btn btn-primary pos-btn1"

                                        OnClick="btnReport_Click" />
      </div>
      
   

                       <div class="row" >
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">

                            </a>
                            <div class="">
                               
                                <div class="circle-tile-description text-faded" style="height:550px">
                                   <asp:Chart ID="Chart1" runat="server" Width="1200px" Height="450px">
                                    <Titles>
                                        <asp:Title Font="Times New Roman, 4pt, style=Bold, Italic" Name="Sales - Socks (NR)"
                                            Text="">
                                        </asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" Color="CadetBlue" Font="Times New Roman, 10pt, style=Bold"
                                            IsValueShownAsLabel="true"  IsVisibleInLegend="false" LegendText="Overall">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Name="Admin">
                                        </asp:Legend>
                                    </Legends>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Interval="1" IntervalType="Number" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                                <MinorGrid />
                                            </AxisX>
                                            <AxisY IsStartedFromZero="true" IsLabelAutoFit="true" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                                </div>

                            </div>
                        </div>
                    </div>
                       </div>     
                       
                       
                         <div class="row">
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">

                            </a>
                            <div class="">
                               
                                <div class="circle-tile-description text-faded" style="height:550px">
                                   <asp:Chart ID="Chart2" runat="server" Width="1200px" Height="450px">
                                    <Titles>
                                        <asp:Title Font="Times New Roman, 4pt, style=Bold, Italic" Name="Sales - Socks (NR)"
                                            Text="">
                                        </asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" Color="CadetBlue" Font="Times New Roman, 10pt, style=Bold"
                                            IsValueShownAsLabel="true"  IsVisibleInLegend="false" LegendText="Overall">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Name="Admin">
                                        </asp:Legend>
                                    </Legends>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Interval="1" IntervalType="Number" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                                <MinorGrid />
                                            </AxisX>
                                            <AxisY IsStartedFromZero="true" IsLabelAutoFit="true" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                                </div>

                            </div>
                        </div>
                    </div>
                       </div>      



                       
                                            
           <div class="row">

            <div id="Div1" class="col-lg-12 col-sm-12" runat="server" visible="false">
                        <div class="circle-tile">

                            <div class="">
                                
                                <div class="circle-tile-number text-faded" style="height:550px">
                                    <asp:Chart ID="Chart3" runat="server" Width="1200px" Height="450px">
                                    <Titles>
                                        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)"
                                            Text="">
                                        </asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Ser1" Color="CadetBlue" Font="Times New Roman, 10pt, style=Bold"
                                            IsValueShownAsLabel="true" IsVisibleInLegend="false" LegendText="Overall">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Name="Admin">
                                        </asp:Legend>
                                    </Legends>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartA1">
                                            <AxisX Interval="1" IntervalType="Number" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                                <MinorGrid />
                                            </AxisX>
                                            <AxisY IsStartedFromZero="true" IsLabelAutoFit="true" ArrowStyle="Triangle">
                                                <MajorGrid LineWidth="0" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                </div>
                                <a href="" class="circle-tile-footer">More Info <i class="fa fa-chevron-circle-right"></i></a>
                            </div>
                        </div>
                    </div>  

                        
           </div>                                 
 
  </div>
  </div>
  </div>
  </div>
  </div>
    </form>

    <script type="text/javascript" src="../js/jquery-3.1.1.js"></script>
    <script type="text/javascript" src="../js/bootstrap.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $(".sidebar-toggle").click(function () {
                    $(this).hide();

                    $("#user-profil").show();

                    $("#hide-btn").show();

                    $(".container-2").css("width", "85%");


                });

                $("#hide-btn").click(function () {
                    $(this).hide();

                    $("#user-profil").hide();

                    $(".sidebar-toggle").show();

                    $(".container-2").css("width", "100%");


                });
            });
    </script>

</body>
</html>