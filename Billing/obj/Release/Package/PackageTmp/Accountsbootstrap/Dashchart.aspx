<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashchart.aspx.cs" Inherits="Billing.Accountsbootstrap.Dashchart" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>DashBoard Details</title>
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
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="../css/style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <%--    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);

        var obj = {};
        obj.name = $.trim($("[id*=firstname]").val());


        function drawChart() {
            var options = {
                title: 'USA City Distribution',
                width: 600,
                height: 400,
                bar: { groupWidth: "95%" },
                legend: { position: "none" },
                isStacked: true
            };
            $.ajax({
                type: "POST",
                url: "Dashchart.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.LineChart($("#chart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <%--<script type="text/javascript">
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Day');
            data.addColumn('number', 'Guardians of the Galaxy');
            data.addColumn('number', 'The Avengers');
            data.addColumn('number', 'Transformers: Age of Extinction');

            data.addRows([
        [1, 37.8, 80.8, 41.8],
        [2, 30.9, 69.5, 32.4],
        [3, 25.4, 57, 25.7],
        [4, 11.7, 18.8, 10.5],
        [5, 11.9, 17.6, 10.4],
        [6, 8.8, 13.6, 7.7],
        [7, 7.6, 12.3, 9.6],
        [8, 12.3, 29.2, 10.6],
        [9, 16.9, 42.9, 14.8],
        [10, 12.8, 30.9, 11.6],
        [11, 5.3, 7.9, 4.7],
        [12, 6.6, 8.4, 5.2],
        [13, 4.8, 6.3, 3.6],
        [14, 4.2, 6.2, 3.4]
      ]);

            var options = {
                chart: {
                    title: 'Box Office Earnings in First Two Weeks of Opening',
                    subtitle: 'in millions of dollars (USD)'
                },
                width: 900,
                height: 500,
                axes: {
                    x: {
                        0: { side: 'top' }
                    }
                }
            };

            var chart = new google.charts.Line(document.getElementById('line_top_x'));

            chart.draw(data, google.charts.Line.convertOptions(options));
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblsTableName" Visible="false"> </asp:Label>
    <div class="row" runat="server" visible="true">
        <div class="col-lg-12">
            <div class="col-lg-3">
                <div style="font-size: xx-large; font-weight: bold">
                    Welcome Back Blaack Forest
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnTextChanged="txtdate_OnTextChanged"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate" Format="yyyy-MM-dd"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlreason_OnSelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div id="Div1" class="col-lg-2" runat="server" visible="false">
                <div class="form-group">
                    <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Stock Return" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-7">
            </div>
        </div>
    </div>
    <%--<div id="line_top_x">
    </div>--%>
    <div>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <div id="chart_div">
        </div>
    </div>
    <div id="chart" style="width: 1000px; height: 500px;">
    </div>
    <div class="col-lg-2">
        <asp:Chart ID="Chart2" runat="server" Height="300px" Width="400px">
            <Titles>
                <asp:Title ShadowOffset="3" Name="Items" />
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Row" />
            </Legends>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
            </ChartAreas>
        </asp:Chart>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="col-lg-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-bar-chart" aria-hidden="true" style="font-size: 40px"></i>
                            </div>
                            <div class="text-center">
                                <div class="huge">
                                    <asp:Label ID="lblSales" runat="server" Text="0"></asp:Label></div>
                                <div>
                                    <h3>
                                        <br />
                                        Sales! for
                                        <asp:Label ID="lblday" runat="server" Text=""></asp:Label></h3>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="panel panel-green">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-bar-chart" aria-hidden="true" style="font-size: 40px"></i>
                            </div>
                            <div class="text-center">
                                <div class="huge">
                                    <asp:Label ID="lblorder" runat="server" Text="0"></asp:Label></div>
                                <div>
                                    <h3>
                                        <br />
                                        Order! for
                                        <asp:Label ID="lblorderday" runat="server" Text=""></asp:Label></h3>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="panel panel-yellow">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-money" aria-hidden="true" style="font-size: 40px"></i>
                            </div>
                            <div class="text-center">
                                <div class="huge">
                                    <asp:Label ID="lblsalesrevenue" runat="server" Text="0"></asp:Label></div>
                                <div>
                                    <h3>
                                        Weekly Sales Revenue! for
                                        <br />
                                        <asp:Label ID="lblsalesrevenuefrom" runat="server" Text=""></asp:Label><br />
                                        <asp:Label ID="lblsalesrevenueto" runat="server" Text=""></asp:Label></h3>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="panel panel-red">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-group" aria-hidden="true" style="font-size: 40px"></i>
                            </div>
                            <div class="text-center">
                                <div class="huge">
                                    <asp:Label ID="lblorderrevenue" runat="server" Text="0"></asp:Label></div>
                                <div>
                                    <h3>
                                        Weekly Order Revenue! for
                                        <br />
                                        <asp:Label ID="lblorderrevenuefrom" runat="server" Text=""></asp:Label><br />
                                        <asp:Label ID="lblorderrevenueto" runat="server" Text=""></asp:Label></h3>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="col-lg-5">
                <label>
                    Up Going Orders Detals
                </label>
                <div style="height: 410px; overflow: scroll">
                    <asp:GridView ID="gvupgoingorders" runat="server" Width="100%" AutoGenerateColumns="false"
                        OnRowDataBound="gvupgoingorders_OnRowDataBound" ShowFooter="true" HeaderStyle-BackColor="Black"
                        HeaderStyle-ForeColor="Wheat" RowStyle-Font-Size="Large" FooterStyle-BackColor="Black"
                        FooterStyle-ForeColor="Wheat" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Customer" DataField="CustomerName" />
                            <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                            <asp:BoundField HeaderText="BookNo" DataField="BookNo" />
                            <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MMM/yy}" />
                            <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yy}" />
                            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:f2}" />
                            <asp:BoundField HeaderText="Paid" DataField="Paid" DataFormatString="{0:f2}" />
                            <asp:BoundField HeaderText="Balance" DataField="BalancePaid" DataFormatString="{0:f2}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-lg-4">
                <label>
                    Sale or Order Chart</label>
                <asp:DropDownList ID="ddlchart" runat="server" AutoPostBack="true" CssClass="form-control"
                    OnSelectedIndexChanged="ddlchart_OnSelectedIndexChanged">
                    <asp:ListItem Text="Sales" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Order" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <div class="circle-tile">
                    <a href="#"></a>
                    <div class="">
                        <div class="circle-tile-description text-faded" style="height: 400px">
                            <asp:Chart ID="Chart1" runat="server" Width="550px" Height="400px">
                                <Titles>
                                    <asp:Title Font="Times New Roman, 4pt, style=Bold, Italic" Name="Sales - Socks (NR)"
                                        Text="">
                                    </asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series Name="Series1" Color="CadetBlue" Font="Times New Roman, 10pt, style=Bold"
                                        IsValueShownAsLabel="true" IsVisibleInLegend="false" LegendText="Overall">
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
            <div class="col-lg-3">
                <label>
                    Sale or Order Item Detals
                </label>
                <asp:DropDownList ID="ddlitems" runat="server" AutoPostBack="true" CssClass="form-control"
                    OnSelectedIndexChanged="ddlitems_OnSelectedIndexChanged">
                    <asp:ListItem Text="Top Sales Items" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Last Sales Items" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Top Order Items" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Last Order Items" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <div style="height: 410px; overflow: scroll">
                    <asp:GridView ID="gvitems" align="center" runat="server" HeaderStyle-BackColor="Black"
                        OnRowDataBound="gvitems_OnRowDataBound" ShowFooter="true" HeaderStyle-ForeColor="Wheat"
                        RowStyle-Font-Size="Large" Width="100%" AutoGenerateColumns="false" FooterStyle-BackColor="Black"
                        FooterStyle-ForeColor="Wheat" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Item" DataField="Item" />
                            <asp:BoundField HeaderText="Qty" DataField="TotalQty" DataFormatString="{0:f2}" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f2}" />
                        </Columns>
                    </asp:GridView>
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
