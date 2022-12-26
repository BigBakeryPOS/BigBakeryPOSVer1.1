<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReduce.aspx.cs" Inherits="Billing.Accountsbootstrap.StockReduce" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head id="Head1">        <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function Search_Gridview(strKey, strGV) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById(strGV);
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }    
</script>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            -moz-opacity: 0.8;
        }
        .GridviewDiv
        {
            font-size: 100%;
            font-family: 'Lucida Grande' , 'Lucida Sans Unicode' , Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }
        .headerstyle
        {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>

     <link rel="stylesheet" href="Tabs/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Tabs/css/style.min.css" />
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>PO Form</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <%--  <script src="js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="js/jquery.responsiveTabs.min.js" type="text/javascript"></script>--%>
    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <%--<script src="js/jquery-2.1.0.min.js" type="text/javascript"></script>--%>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function myFunction() {
            window.open("http://localhost:57111/Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
        }
    </script>
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
    <style>
        .ontop
        {
            z-index: 999;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            display: none;
            position: absolute;
            background-color: #cccccc;
            color: #aaaaaa;
        }
        #popup
        {
            width: 300px;
            height: 200px;
            position: absolute;
            color: #000000;
            background-color: #ffffff; /* To align popup window at the center of screen*/
            top: 50%;
            left: 50%;
            margin-top: -100px;
            margin-left: -150px;
        }
    </style>
    <script type="text/javascript">
        function pop(div) {
            document.getElementById(div).style.display = 'block';
            document.getElementById("btnSave").click();
        }
        function hide(div) {
            document.getElementById(div).style.display = 'none';
        }
        //To detect escape button
        document.onkeydown = function (evt) {
            evt = evt || window.event;
            if (evt.keyCode == 27) {
                hide('popDiv');
            }
        };
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  ChildrenAsTriggers="true" EnableViewState="true"
        UpdateMode="Conditional">
        <ContentTemplate>
       
            <div class="row">
               
                <div >
                    <table  border="0" >
                        <tr>
                            <td style="height:20px;width:300px">
                                <asp:Label runat="server" ID="Label1"> Location</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlvendor"  Width="150px" Visible="true"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlvendor_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" Width="200px" Visible="false"
                                    TextMode="MultiLine" ></asp:TextBox>
                            </td>
                             <td style="height:20px;width:300px">
                                <asp:Label runat="server" ID="Label3">Production No. </asp:Label>
                                <asp:TextBox ID="txtpono"  Width="100px" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="height:20px;width:300px">
                                 <asp:Label runat="server" ID="Label2">Updated by </asp:Label><asp:TextBox ID="txtOrderBy" runat="server" 
                                        Width="200px" ToolTip="Staff Name" required> </asp:TextBox>
                                <asp:Label ID="lblNameerror" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                           
                            <td  style="height:20px;width:300px;padding-left:50px;padding-top:15px">
                                <asp:Label runat="server" ID="Label4"> Production Date</asp:Label>
                                <asp:TextBox ID="txtpodate" Width="200px" runat="server"
                                    Text="--Select Date--"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate"
                                    runat="server" Format="yyyy-MM-dd h:mm tt" >
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1"
                                    ControlToValidate="txtpodate" Style="color: Red" ErrorMessage="Enter PO Date"></asp:RequiredFieldValidator><br />
                            </td>
                        </tr>
                    </table>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlvendor" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="update" runat="server" ChildrenAsTriggers="true" EnableViewState="true"
        UpdateMode="Conditional">
        <ContentTemplate>

           <div id="horizontalTab" style="background-color: #D0D3D6; padding-left: 0px">
                                <%-- <ul>
                                    <li><a href="#tab-1">Gateaux</a></li>
                                    <li><a href="#tab-2">Snacks</a></li>
                                    <li><a href="#tab-3">Puddings</a></li>
                                    <li><a href="#tab-4">Beverages</a></li>
                                    <li><a href="#tab-5">Sweets</a></li>
                                    <li><a href="#tab-6">Party</a></li>
                                    <li><a href="#tab-7">Moouse</a></li>
                                    <li><a href="#tab-8">Cookies</a></li>
                                    <li><a href="#tab-9">Cheese</a></li>
                                    <li><a href="#tab-10">Stores</a></li>
                                    <li><a href="#tab-11">BDC</a></li>
                                    <li><a href="#tab-12">Breads</a></li>
                                    <li><a href="#tab-13">Sponges</a></li>
                                    <li><a href="#tab-14">ReadyMade Sponges</a></li>
                                    <li><a href="#tab-15">ReadyMade Cakes</a></li>
                                    <li><a href="#tab-16">Ice Creams</a></li>
                                </ul>--%>
                                <div>
                                    <div id="tabs">
                                        <div style="background-color: #6a9394;font-family:Calibri; width: 40px" class="c-tabs-nav">
                                            <a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link is-active"
                                                id="tab0" runat="server"><span style="width:90px">
                                                    <label id="lblitem" runat="server">
                                                    </label>
                                                </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                    id="tab1" runat="server"><span style="width:65px">
                                                        <label id="lblitem1" runat="server">
                                                        </label>
                                                    </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                        id="tab2" runat="server"><span style="width:65px">
                                                            <label id="lblitem2" runat="server">
                                                            </label>
                                                        </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                            id="tab3" runat="server"><span style="width:65px">
                                                                <label id="lblitem3" runat="server">
                                                                </label>
                                                            </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                id="tab4" runat="server"><span style="width:150px">
                                                                    <label id="lblitem4" runat="server">
                                                                    </label>
                                                                </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                    id="tab5" runat="server"><span style="width:150px">
                                                                        <label id="lblitem5" runat="server">
                                                                        </label>
                                                                    </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                        id="tab6" runat="server"><span style="width:65px">
                                                                            <label id="lblitem6" runat="server">
                                                                            </label>
                                                                        </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                            id="tab7" runat="server"><span style="width:65px">
                                                                                <label id="lblitem7" runat="server">
                                                                                </label>
                                                                            </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                id="tab8" runat="server"><span style="width:100px">
                                                                                    <label id="lblitem8" runat="server">
                                                                                    </label>
                                                                                </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                    id="tab9" runat="server"><span style="width:65px">
                                                                                        <label id="lblitem9" runat="server">
                                                                                        </label>
                                                                                    </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                        id="tab10" runat="server"><span style="width:120px">
                                                                                            <label id="lblitem10" runat="server">
                                                                                            </label>
                                                                                        </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                            id="tab11" runat="server"><span style="width:65px">
                                                                                                <label id="lblitem11" runat="server">
                                                                                                </label>
                                                                                            </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                                id="tab12" runat="server"><span style="width:65px">
                                                                                                    <label id="lblitem12" runat="server">
                                                                                                    </label>
                                                                                                </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                                    id="tab13" runat="server"><span style="width:65px">
                                                                                                        <label id="lblitem13" runat="server">
                                                                                                        </label>
                                                                                                    </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                                        id="tab14" runat="server"><span style="width:65px">
                                                                                                            <label id="lblitem14" runat="server">
                                                                                                            </label>
                                                                                                        </span></a><a href="#" style="visibility: hidden; background-color: #428bca" class="c-tabs-nav__link"
                                                                                                            id="tab15" runat="server"><span style="width:65px; height:25px">
                                                                                                                <label id="lblitem15" runat="server">
                                                                                                                </label>
                                                                                                            </span></a>
                                        </div>
                                        <%--  <div class="table-responsive">--%>
                                        <div class="c-tab is-active">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 10px">
                                                    <div>
                                                        <table class="table table-bordered table-striped">
                                                            <tr align="center">
                                                                <td> Search :
    <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvGateaux')" CssClass="form-control" Width="200px"></asp:TextBox><br />
   
                                                          <div id="divid" runat="server" style="height: 370px; overflow-x: auto;">
                                                                        <asp:GridView ID="gvGateaux" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                                <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                                <asp:BoundField HeaderText="categoryID" DataField="CategoryID" HeaderStyle-Font-Size="Smaller"
                                                                                    ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                                                                <asp:BoundField HeaderText="SubcategoryID" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller"
                                                                                    ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                                                                <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                    HeaderStyle-Font-Size="Smaller" />
                                                                                <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                    ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                                <asp:TemplateField HeaderText="Qty">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Units">
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                            <HeaderStyle BackColor="#de446e" ForeColor="White" HorizontalAlign="Center" />
                                                                        </asp:GridView>
                                                                       
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox1" runat="server" onkeyup="Search_Gridview(this, 'gvSnacks')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div2" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvSnacks" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" Width="50px" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#de446e" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox2" runat="server" onkeyup="Search_Gridview(this, 'gvPuddings')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div3" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvPuddings" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" Width="50px" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" >
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox3" runat="server" onkeyup="Search_Gridview(this, 'gvBeverages')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div4" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvBeverages" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" Width="50px" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" >
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox4" runat="server" onkeyup="Search_Gridview(this, 'gvSweets')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div5" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvSweets" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" Width="50px" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" Width="50px" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" >
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox5" runat="server" onkeyup="Search_Gridview(this, 'gvcandles')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div6" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvcandles" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox6" runat="server" onkeyup="Search_Gridview(this, 'gvMousse')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div7" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvMousse" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" Width="50px">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" >
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox7" runat="server" onkeyup="Search_Gridview(this, 'gvCookies')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div8" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvCookies" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox8" runat="server" onkeyup="Search_Gridview(this, 'gvcheese')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div9" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvcheese" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox9" runat="server" onkeyup="Search_Gridview(this, 'gvStores')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div10" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvStores" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox10" runat="server" onkeyup="Search_Gridview(this, 'gvBday')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div11" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvBday" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>
                                                            Search :
    <asp:TextBox ID="TextBox11" runat="server" onkeyup="Search_Gridview(this, 'gvbread')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div12" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvbread" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
                                                            <td>Search :
    <asp:TextBox ID="TextBox12" runat="server" onkeyup="Search_Gridview(this, 'gvSponges')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                                <div id="div13" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvSponges" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" Width="50px" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
    <asp:TextBox ID="TextBox13" runat="server" onkeyup="Search_Gridview(this, 'gvReadySp')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                            <td>
                                                                <div id="div14" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvReadySp" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
    <asp:TextBox ID="TextBox14" runat="server" onkeyup="Search_Gridview(this, 'gvRmCake')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                            <td>
                                                                <div id="div15" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvRmCake" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" Width="50px">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="c-tab">
                                            <div class="c-tab__content">
                                                <div class="row" style="background-color: #D0D3D6; padding-left: 30px">
                                                    <table class="table table-bordered table-striped">
                                                        <tr align="center">
    <asp:TextBox ID="TextBox15" runat="server" onkeyup="Search_Gridview(this, 'gvIce')" CssClass="form-control" Width="200px"></asp:TextBox><br />
                                                            <td>
                                                                <div id="div16" runat="server" style="height: 370px; overflow-x: auto;">
                                                                    <asp:GridView ID="gvIce" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                                                DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                                            <asp:BoundField HeaderText="Available Stock" DataField="Available_Qty" DataFormatString="{0:f}"
                                                                                HeaderStyle-Font-Size="Smaller" />
                                                                            <%--<asp:BoundField HeaderText="Uom" DataField="uom" HeaderStyle-Font-Size="Smaller"
                                                                                ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />--%>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false" Width="50px">0</asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Units">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddUnits" runat="server" Width="50px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </div>
                                <div id="hide" runat="server">
                                </div>
                            </div>


            <%--<div id="horizontalTab">
                <ul>
                    <li><a href="#tab-1">Gateaux</a></li>
                    <li><a href="#tab-2">Snacks</a></li>
                    <li><a href="#tab-3">Puddings</a></li>
                    <li><a href="#tab-4">Beverages</a></li>
                    <li><a href="#tab-5">Sweets</a></li>
                    <li><a href="#tab-6">Party Items</a></li>
                    <li><a href="#tab-7">Mousse</a></li>
                    <li><a href="#tab-8">Cookies</a></li>
                    <li><a href="#tab-9">Cheese cake</a></li>
                    <li><a href="#tab-10">Stores</a></li>
                    <li><a href="#tab-11">Birthday Cakes</a></li>
                    <li><a href="#tab-12">Breads</a></li>
                    <li><a href="#tab-13">Sponges</a></li>
                    <li><a href="#tab-14">EggLess Cake</a></li>
                </ul>
                <div id="tab-1" style="">
                    <table class="table table-striped table-bordered table-hover" style="">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvGateaux" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" DataField="CategoryID" HeaderStyle-Font-Size="Smaller"
                                                        ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                                    <asp:BoundField HeaderText="SubcategoryID" DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller"
                                                        ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-2" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvSnacks" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-3" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvPuddings" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-4" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvBeverages" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-5" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvSweets" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-6" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvcandles" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-7" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvMousse" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-8" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvCookies" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-9" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvcheese" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-10" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvStores" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-11" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvBday" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-12" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvbread" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-13" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvSponges" runat="server" AutoGenerateColumns="false" BackColor="#99cc99"
                                                Font-Names="Comic Sans MS" RowStyle-BorderStyle="Double" HeaderStyle-HorizontalAlign="Center"
                                                OnRowDataBound="gvSponges_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="tab-14" style="">
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td style="">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvEggless" runat="server" AutoGenerateColumns="false" BackColor="#99cc99"
                                                Font-Names="Comic Sans MS" RowStyle-BorderStyle="Double" HeaderStyle-HorizontalAlign="Center">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Definition" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="categoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="SubcategoryID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                                        DataField="CategoryUserID" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:BoundField HeaderText="Existing Qty" DataField="Prod_Qty" HeaderStyle-Font-Size="Smaller" />
                                                    <asp:TemplateField HeaderText="Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" AutoPostBack="false">0</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Units">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddUnits" runat="server">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="form-group" align="center">
                    <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                    <asp:Button ID="btnadd" Text="Save" runat="server" Height="50px" class="btn btn-success"
                        Visible="false" ValidationGroup="val1" OnClientClick="showProgress()" />
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btsAVE_Click" />
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
            </div>--%>

              <div class="form-group" align="center">
                    <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                    <asp:Button ID="btnadd" Text="Save" runat="server" Height="50px" class="btn btn-success"
                        Visible="false" ValidationGroup="val1" OnClientClick="showProgress()" />
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClientClick="showProgress()" OnClick="btsAVE_Click" />
                </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="../images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <!-- /.panel-body -->
    <!-- /.panel -->
    <!-- /.col-lg-12 -->

      <script src="Tabs/js/src/tabs.js"></script>
    <script>
        var myTabs = tabs({
            el: '#tabs',
            tabNavigationLinks: '.c-tabs-nav__link',
            tabContentContainers: '.c-tab'
        });

        myTabs.init();
    </script>

        <script src="Tabs/js/lib/githubicons.js"></script>
    <script src="Tabs/js/lib/carbonad.js"></script>
    </form>
</body>
</html>
