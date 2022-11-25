<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreRawItemRequest.aspx.cs" EnableEventValidation ="false"
    Inherits="Billing.Accountsbootstrap.StoreRawItemRequest" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Accept Raw Materials</title>
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
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation

            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";

            }
            return true;
        }
    </script>
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
    <script type="text/javascript">
        function printdata() {
            var gridData = document.getElementById("PRINTID");
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

    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Accept Raw Materials</title>
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>     --%>

    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Accept Raw Materials</h1>
	    </div>
        <div class="panel-body">
                <div class="row">
                <div class="col-lg-3">
                <asp:RadioButtonList ID="radbtnlist" runat="server" RepeatColumns="4" OnSelectedIndexChanged="goodsentrytype"
                    AutoPostBack="true">
                    <asp:ListItem Text="Against Request From Production" Value="1" ></asp:ListItem>
                    <%--<asp:ListItem Text="Accept Request" Value="2"></asp:ListItem>--%>
                    <asp:ListItem Text="Direct Transfer" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Against Demand" Selected="True" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
                                <%--    <blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your Goods  To Your raw Material Request Store.Please Be Carefull While Sending Stock Entry.Thank You!!!</label></blink>--%>
                              
                                    <div class="col-lg-3">
                                       
                                            <asp:Label runat="server" ID="Label2"><label>Request No.</label></asp:Label>
                                            <asp:DropDownList ID="ddlrequestno" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlrequestno_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        
                                    </div>
                                    <div class="col-lg-3">
                                       
                                            <asp:Label runat="server" ID="Label1"><label>Request Date</label></asp:Label>
                                            <asp:TextBox ID="txtrequestdate" runat="server" CssClass="form-control" OnTextChanged="request_changed"
                                                AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtrequestdate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        
                                    </div>
                                    <div class="col-lg-3">
                                       
                                            <asp:Label runat="server" ID="lblDcNo"><label>Accept No.</label></asp:Label>
                                            <asp:TextBox ID="txtDCNo"  runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                                Enabled="false"></asp:TextBox>
                                            <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                    <div class="col-lg-3">
                                     
                                            <asp:Label runat="server" ID="lblDCDate"><label>Accept Date</label></asp:Label>
                                            <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                       
                                    </div>
                                    <div class="col-lg-3">
                                       
                                            <label>
                                                Prepared By</label>
                                            <asp:TextBox ID="txtAccepted" runat="server" CssClass="form-control" ></asp:TextBox>
                                       
                                    </div>
                                    <div class="col-lg-3">
                                        
                                            <label>
                                                From Department</label>
                                            <asp:DropDownList ID="drpdepartment" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                        <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-primary pos-btn1" Text="Send Raw"
                                            OnClientClick="ClientSideClick(this)" UseSubmitBehavior="false" OnClick="btnPrev_Click"
                                            Visible="true" />
                                    </div>
                                    
                                </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                 </div>
                 </div>
     <div class="col-lg-8">
                     <div class="row panel-custom1">
                            <div class="panel-header">
                              <h1 class="page-header">Raw Materials Details</h1>
	                        </div>
                      <div class="panel-body">
                              <div class="row">  
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="drprawcat" runat="server" Width="100%" CssClass="form-control"
                                        OnSelectedIndexChanged="IngCate_indexed" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'GridView2')"
                                        CssClass="form-control" placeholder="Search Raw Materials.." ></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button ID="btnaddqueue" Visible="false" runat="server" Text="Add To Queue List"
                                        CssClass="btn btn-primary pos-btn1" OnClick="add_queue" />
                                </div>
                            </div>
                              <div class="table-responsive panel-grid-left">
                           <asp:GridView ID="GridView2" AutoGenerateColumns="False" ShowFooter="True" Width="100%"
                                    cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" GridLines="Both" runat="server">
                                   <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ingredient Name" ItemStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="Semiitemid" runat="server" Value='<%#Eval("Semiitemid") %>' />
                                                <asp:Label ID="lblIngredientName" runat="server" Text='<%#Eval("IngredientName") %>'
                                                    Width="250px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Store Stock" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStkQty" runat="server" Text='<%# Eval("Currstock") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty" Visible="false" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWantedRaw" runat="server" Text='<%#Eval("WantedRaw") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested Stock" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActRaw" runat="server" Text='<%#Eval("ActRaw") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transfer Qty" HeaderStyle-Width="50px" ItemStyle-Width="65px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtuqty" runat="server" Text='<%#Eval("TQty") %>' Width="65px"></asp:TextBox>
                                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="-" TargetControlID="txtuqty" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Narration" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtqtynarration" runat="server">0</asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Kitchen Stock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrdQty" runat="server" Text='<%#Eval("ProdQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbluom" runat="server" Text='<%#Eval("UOM") %>' Width="50px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                            </div>
                        </div>
                    </div>
     <div class="col-lg-4">
                    <div class="row panel-custom1">
                         <div class="panel-body">
                  
                    <div class="list-group">
                   
                                        <asp:DropDownList ID="drpdcqtywise" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Branch Wise" Value="0" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Overall Wise" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Button ID="btnsearchqty" runat="server" class="btn btn-primary pos-btn1" Text="Get All Branches Qty"
                                            OnClick="btnsearchqty_OnClick" />
                                         &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" class="btn btn-secondary" Text="Print" OnClientClick="printdata()" />
                                       &nbsp;&nbsp;&nbsp; <asp:Button ID="Button4" runat="server" class="btn btn-success" Text="Export-Excel"
                                            OnClick="btnexport_click" />
                                  
                                    </div>
                     <div class="table-responsive panel-grid-left">
                              <div id="PRINTID" runat="server">
                                    <asp:GridView ID="gvbranchqty" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                        OnRowCreated="gvbranchqty_RowCreated" OnRowDataBound="gvbranchqty_RowDataBound"   >
                                      <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                        <Columns>
                                            <asp:BoundField HeaderText="Category" DataField="Category" />
                                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                                    <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                       <%-- <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    </asp:GridView>
                                </div>
                                <div id="PRINTIDRec" runat="server">
                                    <asp:GridView ID="Griddc" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" >
                                       <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                        <Columns>
                                            <asp:BoundField HeaderText="Category" DataField="Category" />
                                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                                            <asp:BoundField HeaderText="Order Qty" DataField="Oqty" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                                    <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                      <%--  <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    </asp:GridView>
                                </div>
                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                   <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Item" DataField="IngreCategory" />
                                        <asp:BoundField HeaderText="Category" DataField="IngredientName" />
                                        <asp:BoundField HeaderText="Qty" DataField="Order_Qty" />
                                    </Columns>
                                  <%--  <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                            </div>
                            
                    <div runat="server" visible="true" class="col-lg-4">
                        <asp:GridView ID="gvRawRequest" runat="server" AutoGenerateColumns="false" Width="100%" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                            Font-Names="Calibri" AllowSorting="true" Caption="Item Details">
                           <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                HorizontalAlign="Center" ForeColor="White" />--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Definition")%>'></asp:Label>
                                        <asp:HiddenField ID="HDProductid" runat="server" Value='<%#Eval("ItemId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblorgQty" runat="server" Text='<%#Eval("orgQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excess Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblexcessqty" runat="server" Text='<%#Eval("excessqty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adj.Qty" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtadjqty" OnTextChanged="Excess_click" AutoPostBack="true" runat="server">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="-" TargetControlID="txtadjqty" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Final Qty" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="txtfinalqty" Text='<%#Eval("Qty")%>' runat="server">0</asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                            <%--<HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                        <asp:GridView ID="gvrawrequestqueue" runat="server" AutoGenerateColumns="false" Width="100%" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                            Font-Names="Calibri" AllowSorting="true" Caption="Raw Materials Details">
                          <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                HorizontalAlign="Center" ForeColor="White" />--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Ingredient Name" ItemStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Semiitemid" runat="server" Value='<%#Eval("Semiitemid") %>' />
                                        <asp:Label ID="lblIngredientName" runat="server" Text='<%#Eval("IngredientName") %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="50px" ItemStyle-Width="65px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluom" runat="server" Text='<%#Eval("UOM") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store Stock" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStkQty" runat="server" Text='<%#Eval("CQty") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transfer Qty" HeaderStyle-Width="50px" ItemStyle-Width="65px">
                                    <ItemTemplate>
                                        <%--<asp:TextBox ID="txtuqty" runat="server" Text='<%#Eval("TQty") %>' Width="65px"></asp:TextBox>--%>
                                        <asp:Label ID="lbluqty" runat="server" Text='<%#Eval("TQty") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Narration" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <%--<asp:TextBox ID="txtqtynarration" runat="server" Text='<%#Eval("Nar") %>' >0</asp:TextBox>--%>
                                        <asp:Label ID="lblqtynarration" runat="server" Text='<%#Eval("Nar") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                        <div class="col-lg-12">
                            <br />
                            <div class="col-lg-2">
                            </div>
                            <div class="col-lg-8">
                                <asp:Label ForeColor="Red" ID="lblMsg" runat="server"></asp:Label>
                                <asp:Button ID="btnexecuteraw" runat="server" Text="Execute raw" CssClass="btn btn-success"
                                    Visible="false" OnClick="btnexecuteraw_OnClick" />
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
</body>
</html>
