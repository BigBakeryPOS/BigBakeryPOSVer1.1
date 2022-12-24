<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DirectStoreGoodsTransfer.aspx.cs" Inherits="Billing.Accountsbootstrap.DirectStoreGoodsTransfer" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Raw Materials Goods Entry</title>
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
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

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
    <script type="text/javascript" language="javascript">
        var oldRowColor;

        // this function is used to change the backgound color

        function ChangeColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                oldRowColor = obj.className;

                obj.className = "HighLightRowColor";

            }

        }

        // this function is used to reset the background color 
        function ResetColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                obj.className = oldRowColor;

            }

        }

    </script>
    <style type="text/css">
        
        .RowStyleBackGroundColor
{

background-color:White;

}

.RowAlternateStyleBackGroundColor

{

background-color:White;

}

.HighLightRowColor

{

background-color:Yellow;
font-weight:bold;
font-size:xx-large;
color:White;

}
        
        
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
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
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
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
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">
    </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false">
    </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false">
    </asp:Label>
    <asp:Label ID="lblcatid" runat="server" Text="(1,2,7)" Visible="false"></asp:Label>
    <form runat="server" id="form1" method="post">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg -12">
                <div class="row panel-custom1">
                    <div class="panel-header">
                        <h1 class="page-header">
                            Raw Materials Goods Entry</h1>
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:RadioButtonList ID="radentrytype" runat="server" Visible="false">
                        <asp:ListItem Text="Manual Type/with-out Stock Reduce" Value="3" Selected="True">
                        </asp:ListItem>
                    </asp:RadioButtonList>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblDcNo">
                                            <label>
                                                Transfer No.</label></asp:Label>
                                <asp:TextBox ID="txtTransferNo" runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                    Enabled="false">
                                </asp:TextBox>
                                <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblDCDate">
                                            <label>
                                                Transfer Date</label></asp:Label>
                                <asp:TextBox ID="txtTransferDate" runat="server" CssClass="form-control">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtTransferDate"
                                    Enabled="false" runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Select Branch</label>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label>
                                    Entry By</label>
                                <asp:TextBox ID="txtEntryBy" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="Label1">
                                            <label>
                                                Category</label></asp:Label>
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlrequestno_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <br />
                                <asp:Button ID="btnaddqueue" runat="server" Text="Add to Queue" OnClick="btnaddqueue_OnClick"
                                    Width="110px" CssClass="btn btn-primary pos-btn1" />
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnPreview" runat="server" CssClass="btn btn-success"
                                    OnClientClick="ClientSideClick(this)" UseSubmitBehavior="false" Text="Send "
                                    OnClick="btnPrev_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">
                                Finished Goods Details</h1>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group has-feedback">
                                        <label>
                                            Search From List
                                        </label>
                                        <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvitems')"
                                            CssClass="form-control" placeholder="Search Category/Item..">
                                        </asp:TextBox>
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group has-feedback">
                                        <label>
                                            Search From Item Master
                                        </label>
                                        <asp:TextBox ID="txtserch" runat="server" OnTextChanged="serach_text" AutoPostBack="true"
                                            CssClass="form-control" placeholder="Search Category/Item..">
                                        </asp:TextBox>
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group has-feedback">
                                        <label>
                                            Search From BarCode
                                        </label>
                                        <asp:TextBox ID="txtbarcode" runat="server" OnTextChanged="search_barcode" AutoPostBack="true"
                                            CssClass="form-control" placeholder="Search Barcode.">
                                        </asp:TextBox>
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvRawRequest" runat="server" AutoGenerateColumns="false" Width="100%"
                                    padding="0" spacing="0" border="0" Font-Size="Medium" Font-Bold="true" AllowSorting="true"
                                    CssClass="table table-striped pos-table">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcategorys" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Definition")%>'></asp:Label>
                                                <asp:HiddenField ID="HDProductid" runat="server" Value='<%#Eval("ItemId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested Stock From Store">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty")%>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock In Hand">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProd_Qty" runat="server" Text='<%#Eval("Prod_Qty")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Frozen Stock In Hand" Visible="true">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPendingfrozenqty" runat="server" Width="100px" runat="server"
                                                    Text='<%#Eval("FrozenQty")%>' Enabled="false">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="" TargetControlID="txtPendingfrozenqty" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Production Output Finished">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtreadyqty" runat="server" Width="100px">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="" TargetControlID="txtreadyqty" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Production Damage">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtdamageqty" runat="server" Width="100px">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="" TargetControlID="txtdamageqty" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Issue Frozen" Visible="true">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtfrozenqty" runat="server" Width="100px">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="" TargetControlID="txtfrozenqty" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Take Frozen" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttakefrozen" runat="server" Width="100px" Enabled="true">0</asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender55" runat="server"
                                                                        FilterType="Numbers,Custom" ValidChars="" TargetControlID="txttakefrozen" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="Un Complete" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtuncomplete" runat="server" Width="100px">0</asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                                        FilterType="Numbers,Custom" ValidChars="" TargetControlID="txtuncomplete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Production Output Stock" Visible="true">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtfinal" runat="server" Width="100px" Enabled="false">0</asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="false" CssClass="table table-striped pos-table"
                                    padding="0" spacing="0" border="0" Width="100%">
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                    <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                    <asp:HiddenField ID="hideitemID" runat="server" Value='<%#Eval("itemid") %>' />
                                                                                                   </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" AutoPostBack="false">0</asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtQty"
                                                        FilterType="Custom,Numbers" ValidChars="." />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                <asp:HiddenField ID="hideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                <asp:HiddenField ID="hdRate" runat="server" Value='<%#Eval("Rate") %>' />
                                                <asp:HiddenField ID="hdGST" runat="server" Value='<%#Eval("GST") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblserial" runat="server" Text='<%#Eval("serial") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server" Text='<%#Eval("MRP") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Avl.Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lbqty" runat="server" Width="50px" Text='<%#Eval("Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server"
                                                    Width="200px" AutoPostBack="false"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtQty"
                                                    FilterType="Custom,Numbers" ValidChars="." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblom" runat="server" Width="50px" Text='<%#Eval("UOM") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%-- <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#428bca" ForeColor="White" HorizontalAlign="Center" />--%>
                                    <%--<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />--%>
                                    <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                    <%--<SelectedRowStyle  Font-Bold="True" ForeColor="white" />--%>
                                    <%--<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />--%>
                                    <%--<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />--%>
                                    <%--<AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />--%>
                                </asp:GridView>
                            </div>
                            <div runat="server" id="single" visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                Select Item</label>
                                            <br />
                                            <asp:DropDownList ID="drpitem" runat="server" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <label>
                                                Qty</label>
                                            <br />
                                            <asp:TextBox ID="txtqty" runat="server">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">
                                Transfer Item List</h1>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvqueueitems" runat="server" AutoGenerateColumns="false" Width="100%"
                                    CssClass="table table-striped pos-table" padding="0" spacing="0" border="0" Font-Names="Calibri"
                                    OnRowCommand="gvqueueitems_RowCommand" OnRowDeleting="gvqueueitems_RowDeleting">
                                    <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                <asp:HiddenField ID="hideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                <asp:HiddenField ID="hdRate" runat="server" Value='<%#Eval("Rate") %>' />
                                                <asp:HiddenField ID="hdGST" runat="server" Value='<%#Eval("GST") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" Width="50px" class="form-control" Text='<%#Eval("Qty") %>'
                                                    Enabled="true">0</asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblom" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="plus" Text="+" runat="server" CommandName="plus" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="minus" Text="-" runat="server" CommandName="minus" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <asp:GridView ID="GridView2" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-striped pos-table"
                                    padding="0" spacing="0" border="0" Caption="Raw Materials Details" GridLines="Both"
                                    Width="100%" runat="server">
                                    <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ingredient Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="Semiitemid" runat="server" Value='<%#Eval("Semiitemid") %>' />
                                                <asp:Label ID="lblIngredientName" runat="server" Text='<%#Eval("IngredientName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Kitchen Stock" DataField="RawStock" />
                                        <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWantedRaw" runat="server" Text='<%#Eval("WantedRaw") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Unit" DataField="UOM" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        window.onload = function () {
            $(".chzn-select").chosen();
            $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        } </script>
    </form>
</body>
</html>

