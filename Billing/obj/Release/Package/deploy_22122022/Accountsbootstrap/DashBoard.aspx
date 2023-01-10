<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Billing.Accountsbootstrap.DashBoard" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" style="overflow: auto;">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1">
    <title></title>
    <link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-fileupload.css" rel="stylesheet" type="text/css" />
    <script src="js/glyphicon1.js" type="text/javascript"></script>
    <script src="js/glyphicon2.js" type="text/javascript"></script>
    <link href="../css/submenu1.css" rel="stylesheet" type="text/css" />
    <link href="css/glyphicons.css" rel="stylesheet" type="text/css" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <%--<menu:menu ID="menu" runat="server" />--%>
    <%--  Row1--%>
    <div style="margin-top: 0px" id="visible" runat="server">
        <%--  Row2--%>
        <div class="row" style="padding-left: 50px">
            <div class="form-control" id="admin" runat="server" style="display: none">
                <label>
                    Select Branch
                </label>
                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="KK Nagar" Value="CO1"></asp:ListItem>
                    <asp:ListItem Text="Byepass" Value="CO2"></asp:ListItem>
                    <asp:ListItem Text="BB Kulam" Value="CO3"></asp:ListItem>
                    <asp:ListItem Text="Narayanapuram" Value="CO4"></asp:ListItem>
                    <asp:ListItem Text="Nellai" Value="CO5"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-12">
                <%-- column1--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-shopping-cart" style="font-size: 80px">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storesalesAmt" runat="server">
                                        <asp:Label ID="Label7" Text="Counter sales:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblsales" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                        <asp:Label ID="Label9" Text="Cake Orders Sales:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblorder" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b>
                                    </div>
                                    <div class="huge" id="adminsalesAmount" runat="server" visible="false">
                                        <asp:GridView ID="gvsalesAmt" runat="server" CssClass="mGrid" Caption="Counter Sale Amount"
                                            Style="color: White">
                                            <HeaderStyle BackColor="#3072ab" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                    <div class="">
                                        <h3>
                                            Sales</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- column2--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-bell" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storeorderAmt" runat="server">
                                        <asp:Label ID="Label8" ForeColor="White" Text="Counter Food Fall:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblsalescount" ForeColor="White" runat="server">0</asp:Label></b><br />
                                        <asp:Label ID="Label12" ForeColor="White" Text="Cake orders:" runat="server"></asp:Label>
                                        <asp:Label ID="lblOrdercount" ForeColor="White" runat="server">0</asp:Label>
                                    </div>
                                    <div class="" id="adminorderAmt" runat="server" visible="false">
                                        <asp:GridView ID="gvbillCount" runat="server" CssClass="mGrid" Caption="Bill Count"
                                            Width="50%">
                                            <HeaderStyle BackColor="#5cb85c" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Food Fall</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- column3--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #66224b">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-road" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storevalue" runat="server">
                                        <asp:Label ID="Label14" runat="server" Visible="false" Text="0"></asp:Label>
                                        <asp:Label ID="Label10" ForeColor="White" Text="Total Stock Value:" runat="server"></asp:Label></b>
                                        <b>
                                            <asp:Label ID="lblStockValue" ForeColor="White" Text="" runat="server"></asp:Label><br />
                                            <asp:Label ID="lbllvstatus" ForeColor="White" Text="Stock Returned / Wasted value:"
                                                runat="server"></asp:Label></b> <b>
                                                    <asp:Label ID="lblRet" ForeColor="White" runat="server"></asp:Label>
                                    </div>
                                    <div class="huge" id="adminvalue" runat="server" visible="false">
                                        <asp:GridView ID="gvstock" runat="server" CssClass="mGrid" Caption="Values">
                                        </asp:GridView>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Stock</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="">
                            <div class="panel-footer">
                                <%--<span class="pull-left" style="color:#f0ad4e">View Details</span>--%>
                                <span class="pull-left" style="color: #66224b">
                                    <marquee direction="left" onmouseover="this.stop();" onmouseout="this.start();" scrolldelay="100"
                                        scrollamount="2" loop="true" height="50%" width="100%">
               
  <b>  <asp:Label ID="lblleave" runat="server" ForeColor="#66224b"></asp:Label></b>
   <asp:TextBox ID="txtmsg" Height="50px" CssClass="form-control" TextMode="MultiLine" ForeColor="Red" Visible="false"
                        runat="server"></asp:TextBox></marquee>
                                </span>
                                <%-- <span class="pull-right" style="color:#f0ad4e"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>--%>
                                <div class="clearfix" style="color: #66224b">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding-left: 50px">
            <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-user" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storecust" runat="server">
                                        <asp:Label ID="Email_ID1" ForeColor="White" Text=" Total Customers Visited:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblCustCount" ForeColor="White" Text=" Email_ID:" runat="server"></asp:Label></b><br />
                                        <asp:Label ID="Label4" Text="Customers Visited Today:" ForeColor="White" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lbltodayCust" ForeColor="White" Text=" Contact_No" runat="server"> </asp:Label></b>
                                    </div>
                                    <div class="huge" id="admincust" runat="server" visible="false">
                                        <asp:GridView ID="gvcustcunt" runat="server" CssClass="mGrid">
                                        </asp:GridView>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Customers
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #52b5d2">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-ban-circle" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storecancel" runat="server">
                                        <asp:Label ID="Label11" ForeColor="White" Text="Cancelled Bills: " runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblTodaybillcancel" ForeColor="White" runat="server"></asp:Label></b>
                                        <br />
                                        <asp:Label ID="Label1" ForeColor="White" Text="Cancelled Orders: " runat="server"></asp:Label>
                                        <asp:Label ID="lblOrdercancelToday" ForeColor="#52b5d2" Text="Click to Get Your PaySlip"
                                            runat="server"></asp:Label>
                                    </div>
                                    <div class="huge" id="admincancel" runat="server" visible="false">
                                        <asp:GridView ID="gvcancel" runat="server" Caption="cancelled Bills" CssClass="mGrid">
                                        </asp:GridView>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Cancelled
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #8b44a2">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-bullhorn" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <marquee onmouseover="this.stop();" onmouseout="this.start();" direction="left" scrolldelay="150"
                                            scrollamount="2" loop="true" height="100%" width="100%">
                            <asp:Label ID="lblmessege" ForeColor="White" Text="  " runat="server"></asp:Label></marquee>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Message from Production</h3>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding-left: 50px">
            <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #f0ad4e">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-gift" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" id="storedelivery" runat="server">
                                        <asp:Label ID="Label3" runat="server" Visible="false" Text="0"></asp:Label>
                                        <asp:Label ID="Label16" ForeColor="White" Text="Total Cake orders: " runat="server"></asp:Label></b>
                                        <b>
                                            <asp:Label ID="lbltotalcake" ForeColor="White" runat="server"></asp:Label><br />
                                            <b>
                                                <asp:Label ID="Label19" ForeColor="White" Text="Today Cake Orders" runat="server"></asp:Label>
                                                <asp:Label ID="lblordersToday" ForeColor="White" runat="server"></asp:Label></b>
                                    </div>
                                    <div class="huge" id="admindelivery" runat="server" visible="false">
                                        <asp:GridView ID="gvcakesorders" runat="server" CssClass="mGrid">
                                        </asp:GridView>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Cake Orders</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #d8514d">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-calendar" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <b>
                                            <asp:Label ID="lbbirthday" ForeColor="White" Text="No Birthdays Notified Till Now"
                                                runat="server"></asp:Label></b>
                                        <asp:Label ID="Label20" Text="Contact No:" ForeColor="#d8514d" runat="server"></asp:Label>
                                        <asp:Label ID="Label22" Text="" ForeColor="#d8514d" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="Label23" ForeColor="#d8514d" Text="" runat="server"> </asp:Label></b>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Birthday Notification</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #38624c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-comment" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <marquee onmouseover="this.stop();" onmouseout="this.start();" direction="left" scrolldelay="150"
                                            scrollamount="2" loop="true" height="100%" width="100%">
                                      <asp:Label ID="Labelmsg"  style="text-transform:uppercase;text-decoration:blink" Text="" ForeColor="White" runat="server"></asp:Label></marquee>
                                        <b>
                                            <asp:Label ID="Label24" ForeColor="#38624c" runat="server"></asp:Label></b>
                                        <br />
                                        <asp:Label ID="Label25" ForeColor="#38624c" Text="" runat="server"></asp:Label>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Notifications</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="margin-top: 0px" id="Production" runat="server">
        <%--  Row2--%>
        <div class="row" style="padding-left: 50px">
            <div style="padding-top: 100px" class="col-lg-12">
                <h2>
                    Welcome To Production</h2>
            </div>
            <div class="col-lg-12">
                <%-- column1--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-shopping-cart" style="font-size: 80px">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="Label2" Text="No of Items Purchased Today:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblNoofItems" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                        <asp:Label ID="Label5" Text="Purchase Value:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblvalues" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b>
                                    </div>
                                    <div class="">
                                        <h3>
                                            Purchase</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- column2--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #5cb85c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-bell" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="Label15" ForeColor="White" Text="Toal Production:" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblused" ForeColor="White" runat="server">0</asp:Label></b><br />
                                        <asp:Label ID="Label18" ForeColor="White" Text="Total Wastage:" runat="server"></asp:Label>
                                        <asp:Label ID="lblwaste" ForeColor="White" runat="server">0</asp:Label>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Production</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- column3--%>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #66224b">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-road" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="Label26" runat="server" Visible="false" Text="0"></asp:Label>
                                        <asp:Label ID="Label27" ForeColor="White" Text="Total Stock Value:" runat="server"></asp:Label></b>
                                        <b>
                                            <asp:Label ID="lblStock" ForeColor="White" Text="" runat="server"></asp:Label><br />
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Stock</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="">
                            <div class="panel-footer">
                                <%--<span class="pull-left" style="color:#f0ad4e">View Details</span>--%>
                                <span class="pull-left" style="color: #66224b">
                                    <marquee direction="left" onmouseover="this.stop();" onmouseout="this.start();" scrolldelay="100"
                                        scrollamount="2" loop="true" height="50%" width="100%">
               
  <b>  <asp:Label ID="Label31" runat="server" ForeColor="#66224b"></asp:Label></b>
   <asp:TextBox ID="TextBox1" Height="50px" CssClass="form-control" TextMode="MultiLine" ForeColor="Red" Visible="false"
                        runat="server"></asp:TextBox></marquee>
                                </span>
                                <%-- <span class="pull-right" style="color:#f0ad4e"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>--%>
                                <div class="clearfix" style="color: #66224b">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding-left: 50px">
            <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #8b44a2">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-bullhorn" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <marquee onmouseover="this.stop();" onmouseout="this.start();" direction="left" scrolldelay="150"
                                            scrollamount="2" loop="true" height="100%" width="100%">
                            <asp:Label ID="lblpromsg" ForeColor="White" Text="" runat="server"></asp:Label></marquee>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Message from Stores</h3>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #38624c">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-comment" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <marquee onmouseover="this.stop();" onmouseout="this.start();" direction="left" scrolldelay="150"
                                            scrollamount="2" loop="true" height="100%" width="100%">
                                      <asp:Label ID="Label50"  style="text-transform:uppercase;text-decoration:blink" Text="" ForeColor="White" runat="server"></asp:Label></marquee>
                                        <b>
                                            <asp:Label ID="Label51" ForeColor="#38624c" runat="server"></asp:Label></b>
                                        <br />
                                        <asp:Label ID="Label52" ForeColor="#38624c" Text="" runat="server"></asp:Label>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Notifications</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding-left: 50px">
            <div class="col-lg-12 ">
                <div class="col-lg-4 col-md-6">
                    <div class="panel" style="background-color: #d8514d; display: none">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class=" text-center glyphicon glyphicon-calendar" style="font-size: 80px; color: White">
                                    </i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <b>
                                            <asp:Label ID="Label46" ForeColor="White" Text="No Birthdays Notified Till Now" runat="server"></asp:Label></b>
                                        <asp:Label ID="Label47" Text="Contact No:" ForeColor="#d8514d" runat="server"></asp:Label>
                                        <asp:Label ID="Label48" Text="" ForeColor="#d8514d" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="Label49" ForeColor="#d8514d" Text="" runat="server"> </asp:Label></b>
                                    </div>
                                    <div class="" style="color: White">
                                        <h3>
                                            Birthday Notification</h3>
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
