<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsTransferNew.aspx.cs"
    Inherits="Billing.Accountsbootstrap.GoodsTransferNew" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Request Raw Materials</title>
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>
    <style type="text/css">
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript">
        //    function ClientSideClick(myButton) {
        //        // Client side validation
        //        if (typeof (Page_ClientValidate) == 'function') {
        //            if (Page_ClientValidate() == false)
        //            { return false; }
        //        }

        //        //make sure the button is not of type "submit" but "button"
        //        if (myButton.getAttribute('type') == 'button') {
        //            // disable the button
        //            myButton.disabled = true;
        //            myButton.className = "btn-inactive";
        //            myButton.value = "processing...";
        //        }
        //        return true;
        //    }
    </script>
    <%--<script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();

        }
     
    
    </script>--%>
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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #dialog
        {
            display: none;
        }
        
        .ui-dialog-title, .ui-dialog-content, .ui-widget-content
        {
            font-family: "Trebuchet MS" , "Helvetica" , "Arial" , "Verdana" , "sans-serif";
            font-size: 62.5%;
        }
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .GridPager a, .GridPager span
        {
            display: block;
            height: 15px;
            width: 15px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }
        .GridPager a
        {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }
        .GridPager span
        {
            background-color: #A1DCF2;
            color: #000;
            border: 1px solid #3AC0F2;
        }
    </style>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 900px;
            text-align: center;
            border: 3px solid #0DA9D0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 40px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            padding: 5px;
        }
        .modalPopup .footer
        {
            padding: 3px;
        }
        .modalPopup .button
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        .modalPopup td
        {
            text-align: left;
        }
        
        .pad
        {
            padding-top: 50px;
        }
    </style>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
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

    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Request Raw Materials</title>
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
    <script type="text/javascript">
        function Showalert() {
            alert('Check Stock !');
        }
    </script>
    <script type="text/javascript">
        function printGriddetailed() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <script type="text/javascript">
        function printGridsummary() {
            var gridData = document.getElementById('<%= GridView2.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-lg-12" style="">
                <div class="panel panel-default" style="">
                    <div class="panel-heading " style="background-color: #428bca; color: White">
                        <b>Raw Material Request Details</b></div>
                    <div class="panel-body" style="">
                        <div class="row" style="">
                            <div class="col-lg-12" style="">
                                <div class="panel-body" style="height: 68px">
                                    <div style="">
                                        <blink> <label  style="color:Green; font-size:12px">Red Colour Indicate.Receipe Not Set To this Items.Thank You!!!</label></blink>
                                        <div class="row" style="">
                                            <div class="col-lg-2" style="">
                                                <div class="form-group" style="">
                                                    <asp:Label runat="server" ID="Label2"><label>Select Entry Type</label></asp:Label>
                                                    <asp:DropDownList ID="drpentrytype" runat="server" CssClass="form-control" OnSelectedIndexChanged="entryType_Chnaged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Text="Manual Production" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="From Branch Wise/GRN" Value="2" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-2" style="">
                                                <div class="form-group" style="">
                                                    <asp:Label runat="server" ID="lblDcNo"><label>Raw Material Request No.</label></asp:Label>
                                                    <asp:TextBox ID="txtDCNo" Width="150px" runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-2" style="">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="lblDCDate"><label>Raw Material Request Date</label></asp:Label>
                                                    <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                        Format="dd/MM/yyyy hh:mm tt" runat="server" CssClass="cal_Theme1">
                                                    </ajaxToolkit:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="col-lg-2" style="">
                                                <div class="form-group">
                                                    <label>
                                                        Prepared By</label>
                                                    <asp:TextBox ID="txtAccepted" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-2" style="">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label1"><label>Requested Date From Store</label></asp:Label>
                                                    <asp:TextBox ID="txtreqdate" OnTextChanged="reqdate_chnaged" AutoPostBack="true"
                                                        runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txtreqdate"
                                                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                                    </ajaxToolkit:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>
                                                        Search</label>
                                                    <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvPurchase')"
                                                        CssClass="form-control" Width="200px"></asp:TextBox>
                                                </div>
                                               
                                                <div class="col-lg-8" runat="server">
                                                    <asp:TextBox ID="txtexcessqtyfill" runat="server" placeholder="Fill Excess Qty For All Product"
                                                        Visible="false" CssClass="form-control" OnTextChanged="fillexcess" AutoPostBack="true"></asp:TextBox>
                                                    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        AllowSorting="true" OnRowDataBound="gvPurchase_rowdatabound"
                                                        OnSorting="gvPurchase_Sorting" Caption="Fill Excess Qty For All Product">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                                                    <asp:HiddenField ID="HDCategoryid" runat="server" Value='<%#Eval("categoryid") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("product")%>'></asp:Label>
                                                                    <asp:HiddenField ID="HDProductid" runat="server" Value='<%#Eval("productid") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQty1" runat="server" Text='<%#Eval("Qty1")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty2">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQty2" runat="server" Text='<%#Eval("Qty2")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty3">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQty3" runat="server" Text='<%#Eval("Qty3")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty4">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQty4" runat="server" Text='<%#Eval("Qty4")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty5">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQty5" runat="server" Text='<%#Eval("Qty5")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Excess/Manual Entry">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtexcess" OnTextChanged="Excess_click" AutoPostBack="true" runat="server">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                        <%--<HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                    </asp:GridView>
                                                    <br />
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-3">
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:Label ForeColor="Red" ID="lblMsg" runat="server"></asp:Label>
                                                            <asp:Button ID="btnvalue" runat="server" Text="Execute raw" OnClick="RawMaterial_generate"
                                                                CssClass="btn btn-success" />
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-danger" Text="Send Request"
                                                                OnClick="btnPrev_Click" Visible="true" /></div>
                                                        <div class="col-lg-3">
                                                        </div>
                                                    </div>
                                                </div>
                                                 <div class="col-lg-4">
                                                    <div class="panel panel-default" style="">
                                                        <div class="panel-heading " style="background-color: #428bca; color: White">
                                                            Raw Materials</div>
                                                        <div class="panel-body" style="">
                                                            <div class="col-lg-12">
                                                                <div class="col-lg-6">
                                                                    <label>
                                                                        Choose Report</label>
                                                                    <asp:RadioButtonList runat="server" ID="idtype" OnSelectedIndexChanged="radchnaged"
                                                                        AutoPostBack="true" RepeatColumns="2">
                                                                        <asp:ListItem Text="Summary" Value="1" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Details" Value="2"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <asp:Button ID="btnsummary" Text="Print-S" runat="server" CssClass=" btn btn-info"
                                                                        OnClientClick="printGridsummary()" Visible="true" /></div>
                                                                <div class="col-lg-3">
                                                                    <asp:Button ID="btndetails" Text="Print-D" runat="server" CssClass=" btn btn-info"
                                                                        OnClientClick="printGriddetailed()" Visible="false" /></div>
                                                            </div>
                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowCreated="gridraw_RowCreated"
                                                                OnRowDataBound="gridraw_RowDataBound" ShowFooter="True" GridLines="Both"
                                                                Width="80%" runat="server">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Category " ControlStyle-Width="100%" ItemStyle-Width="6%"
                                                                        HeaderStyle-Width="2%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="newcatid" Visible="false" Text='<%# Eval("catID")%>' runat="server"></asp:Label>
                                                                            <asp:Label ID="newcatname" Text='<%# Eval("catName")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Item Name" ControlStyle-Width="100%" ItemStyle-Width="6%"
                                                                        HeaderStyle-Width="2%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="newitemid" Visible="false" Text='<%# Eval("ID")%>' runat="server"></asp:Label>
                                                                            <asp:Label ID="newitemname" Text='<%# Eval("IngredientName")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Kitchen Stock" Visible="true" HeaderStyle-Width="40%"
                                                                        ItemStyle-HorizontalAlign="Right" ControlStyle-Width="50%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpqty" Text='<%# Eval("ProdQty")%>' runat="server"></asp:Label>
                                                                            <%--<asp:TextBox ID="txtqty" Text='<%# Eval("Qty")%>' runat="server" Width="100%" CssClass="form-control"></asp:TextBox>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Process Qty" Visible="false" HeaderStyle-Width="40%"
                                                                        ItemStyle-HorizontalAlign="Right" ControlStyle-Width="50%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqty" Text='<%# Eval("Qty")%>' runat="server"></asp:Label>
                                                                            <%--<asp:TextBox ID="txtqty" Text='<%# Eval("Qty")%>' runat="server" Width="100%" CssClass="form-control"></asp:TextBox>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Stock" Visible="true" HeaderStyle-Width="40%"
                                                                        ItemStyle-HorizontalAlign="Right" ControlStyle-Width="50%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqty" Text='<%# Eval("ActQty")%>' runat="server"></asp:Label>
                                                                            <%--<asp:TextBox ID="txtqty" Text='<%# Eval("Qty")%>' runat="server" Width="100%" CssClass="form-control"></asp:TextBox>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="UOM " ControlStyle-Width="100%" ItemStyle-Width="6%"
                                                                        HeaderStyle-Width="2%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="newuomid" Visible="false" Text='<%# Eval("uomID")%>' runat="server"></asp:Label>
                                                                            <asp:Label ID="newuomname" Text='<%# Eval("uom")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:GridView ID="GridView2" AutoGenerateColumns="False" ShowFooter="True"
                                                                GridLines="Both" Width="80%" runat="server">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex+1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                                                                     <%--<asp:BoundField HeaderText="Kitchen Stock" DataField="ProdQty" ItemStyle-HorizontalAlign="Right"
                                                                        DataFormatString="{0:f}" />--%>
                                                                    <asp:BoundField HeaderText="Total" DataField="WantedRaw" ItemStyle-HorizontalAlign="Right" Visible="false"
                                                                         />
                                                                    <asp:BoundField HeaderText="Actual Stock" DataField="ActualRaw" ItemStyle-HorizontalAlign="Right"
                                                                         />
                                                                    <asp:BoundField HeaderText="Unit" DataField="UOM" />
                                                                    <%-- <asp:TemplateField HeaderText="Ingredient Name" ControlStyle-Width="100%" ItemStyle-Width="6%"
                                                    HeaderStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="newitemname" Text='<%# Eval("IngredientName")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total" HeaderStyle-Width="40%" ControlStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" Text='<%# Eval("WantedRaw")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="40%" ControlStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-lg-6 (nested) -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
 <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999;  opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif" AlternateText="Loading  Please wait..." ToolTip="Loading  Please wait..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>


</ProgressTemplate>
</asp:UpdateProgress>--%>
    <div>
        <asp:LinkButton ID="lnkbtn" Text="" runat="server"></asp:LinkButton>
        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
            CancelControlID="ButtonDeleteCancel" TargetControlID="lnkbtn" PopupControlID="DivDeleteConfirmation"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ScrollBars="Auto" Height="600px" Width="900px" ID="DivDeleteConfirmation"
            CssClass="modalPopup" runat="server">
            <div>
                <div align="center">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div19" runat="server" style="overflow: auto; height: 450px">
                                    <asp:GridView ID="GridView11" runat="server" CssClass="mGrid" AllowPaging="false"
                                        EmptyDataText="No Item Avaliable " AutoGenerateColumns="false" Width="100%">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Item Name" DataField="Item" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                        </Columns>
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                    <%--<input id="ButtonDeleleOkay" type="button" value="Yes" />--%>
                    <input id="ButtonDeleteCancel" type="button" cssclass="btn btn-danger" value="Cancel" />
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
