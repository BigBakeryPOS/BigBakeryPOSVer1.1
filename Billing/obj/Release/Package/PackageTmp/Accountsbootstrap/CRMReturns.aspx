<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMReturns.aspx.cs" Inherits="Billing.Accountsbootstrap.CRMReturns" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">CRM Returns</h1>
	    </div>
    <div class="panel-body">
      <%--<div class="row">
     <div class="col-md-12">
      <div class="page-title">
       <h2></h2>
        <ol class="breadcrumb" >
         <li class="active" style="font-size:30px" ><i class="fa fa-dashboard" ></i> Dashboard</li>
          <li class="pull-right">
           <div id="reportrange"  class="btn btn-green btn-square date-picker">
            <i class="fa fa-calendar"></i>
             <span class="date-range"><label id="lbldatenow" runat="server"  ></label></span> 
           </div>
          </li>
        </ol>
       </div>
      </div>
     </div> --%>    
                      
     <div class="col-md-3">
     
     <label>Select Type</label>
      <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlType_Change">
      <asp:ListItem Text="--Select Type--" Selected=True Value="Select Type"></asp:ListItem>
      <asp:ListItem Text="TopCategoryWise" Value="TopCategoryWise"></asp:ListItem>
      <asp:ListItem Text="LastCategoryWise" Value="LastCategoryWise"></asp:ListItem>
      <asp:ListItem Text="TopProductWise" Value="TopProductWise"></asp:ListItem>
      <asp:ListItem Text="LastProductWise" Value="LastProductWise"></asp:ListItem>

       <asp:ListItem Text="TopReasonsWise" Value="TopReasonsWise"></asp:ListItem>
      <asp:ListItem Text="LastReasonsWise" Value="LastReasonsWise"></asp:ListItem>
      </asp:DropDownList>
      </div>


        <div class="col-md-3"  runat="server" visible="false" id="idsstype">
     
     <label>Select SubType  </label>
      <asp:DropDownList ID="ddlSubType" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlSubType_OnSelectedIndexChanged">
      <asp:ListItem Text="--Select SubType--" Selected=True Value="Select Type"></asp:ListItem>
      <asp:ListItem Text="TopCategoryWise" Value="TopCategoryWise"></asp:ListItem>
      <asp:ListItem Text="LastCategoryWise" Value="LastCategoryWise"></asp:ListItem>
    <%--  <asp:ListItem Text="TopProductWise" Value="TopProductWise"></asp:ListItem>
      <asp:ListItem Text="LastProductWise" Value="LastProductWise"></asp:ListItem>--%>
      </asp:DropDownList>
      </div>

      <div class="col-md-3"  runat="server" visible="false" id="divState">
      <label> Select State </label>
      <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlState_Change"></asp:DropDownList>
      </div>

      </div>
     
                       <div class="row">
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">
                                <%--<div class="circle-tile-heading green">
                                    <i class="fa fa-money fa-fw fa-3x"></i>
                                </div>--%>
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
                                <%--<a href="" class="circle-tile-footer">More Info <i class="fa fa-chevron-circle-right"></i></a>--%>
                            </div>
                        </div>
                    </div>
                       </div>     
                       
                       
                         <div class="row">
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">
                              <%--  <div class="circle-tile-heading green">
                                    <i class="fa fa-money fa-fw fa-3x"></i>
                                </div>--%>
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
                                <%--<a href="" class="circle-tile-footer">More Info <i class="fa fa-chevron-circle-right"></i></a>--%>
                            </div>
                        </div>
                    </div>
                       </div>      


                       <%--  <div class="row">
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">
                                <div class="circle-tile-heading green">
                                    <i class="fa fa-money fa-fw fa-3x"></i>
                                </div>
                            </a>
                            <div class="">
                               
                                <div class="circle-tile-description text-faded" style="height:550px">
                                   <asp:Chart ID="Chart4" runat="server" Width="1200px" Height="450px">
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
                                <a href="" class="circle-tile-footer">More Info <i class="fa fa-chevron-circle-right"></i></a>
                            </div>
                        </div>
                    </div>
                       </div>     
                       
                       
                         <div class="row">
                       <div class="col-lg-12 col-sm-12" >
                        <div class="circle-tile">
                           <a href="#">
                                <div class="circle-tile-heading green">
                                    <i class="fa fa-money fa-fw fa-3x"></i>
                                </div>
                            </a>
                            <div class="">
                               
                                <div class="circle-tile-description text-faded" style="height:550px">
                                   <asp:Chart ID="Chart5" runat="server" Width="1200px" Height="450px">
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
                                <a href="" class="circle-tile-footer">More Info <i class="fa fa-chevron-circle-right"></i></a>
                            </div>
                        </div>
                    </div>
                       </div>      --%>
                       
                                            
           <div class="row">

            <div id="Div1" class="col-lg-12 col-sm-12" runat="server" visible="false">
                        <div class="circle-tile">
                            <%--<a href="#">
                                <div class="circle-tile-heading green">
                                    <i class="fa fa-money fa-fw fa-3x"></i>
                                </div>
                            </a>--%>
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
