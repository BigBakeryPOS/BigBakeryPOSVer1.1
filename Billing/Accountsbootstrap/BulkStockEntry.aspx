<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkStockEntry.aspx.cs"
    Inherits="Billing.Accountsbootstrap.BulkStockEntry" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Bulk Stock Entry </title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <%-- <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtBrandname'), "Branch Name")
            {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
    </script>--%>
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false) { return false; }
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
    <style type="text/css">
        blink, .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
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
        .RowStyleBackGroundColor {
            background-color: White;
        }

        .RowAlternateStyleBackGroundColor {
            background-color: White;
        }

        .HighLightRowColor {
            background-color: Silver;
            font-weight: bold;
            font-size: xx-large;
            color: White;
        }
    </style>
    <!-- Bootstrap Core CSS -->
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <%--<link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="../js/jquery-2.1.0.min.js" type="text/javascript"></script>--%>
    <!-- Custom Fonts -->

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .Hide {
            display: none;
        }

        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                    <h1 class="page-header">Bulk Stock Entry<asp:Label ID="lblentrydatetime" runat="server" Visible="false"></asp:Label>
                                        <span class="pull-right">

                                            <asp:LinkButton ID="btnadd" runat="server" OnClick="btnsave_Click" OnClientClick="ClientSideClick(this)">
                    <button type="button" class="btn btn-info btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                                            </asp:LinkButton>
                                        </span>
                                    </h1>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <div class="col-lg-12">
                                            <div align="left" style="display: none">
                                                <blink>
                                                    <label>Need to Fill as Per Your daily Stock Request.Once Fill not Allow To change So Be careFull To fill this Request!!!. </label>
                                                </blink>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>
                                                    GRN.No</label>
                                                <asp:TextBox ID="txtpono" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>
                                                    GRN. Date
                                                </label>
                                                <asp:TextBox ID="txtpodate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate"
                                                    Format="dd/MM/yyyy" PopupButtonID="txtnewexpiredDate" EnabledOnClient="true"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>
                                                    Employee Name
                                                </label>
                                                <asp:TextBox ID="txtOrderBy" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>
                                                    Select Type</label>
                                                <asp:RadioButtonList ID="radbtntype" runat="server" OnSelectedIndexChanged="radbtn_clicked"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Text="GridLoad" Selected="True" Value="1"></asp:ListItem>
                                                    <%--<asp:ListItem Text="Item Load" Value="2" Selected="True"></asp:ListItem>--%>
                                                    <asp:ListItem Text="POS like Item Load" Value="3"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>
                                                    Category
                                                </label>
                                                <asp:DropDownList runat="server" ID="ddlcategory" class="form-control" TabIndex="1"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>
                                                    Search Item
                                                </label>
                                                <asp:TextBox ID="TextBox10" runat="server" onkeyup="Search_Gridview(this, 'gvitems')"
                                                    CssClass="form-control"></asp:TextBox><br />
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Button ID="btnaddqueue" runat="server" Text="Add to Queue" OnClick="btnaddqueue_OnClick"
                                                    CssClass="btn btn-danger pos-btn1" />
                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnexit" runat="server" Text="Exit" CssClass="btn btn-secondary" PostBackUrl="~/Accountsbootstrap/Stock.aspx" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div runat="server" visible="false" id="searchdiv" class="col-lg-12">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>
                                                                Search From List
                                                            </label>
                                                            <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvitems')"
                                                                CssClass="form-control" placeholder="Search Category/Item.." Width="200px">
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>
                                                                Search From Item Master
                                                            </label>
                                                            <asp:TextBox ID="txtserch" runat="server" OnTextChanged="serach_text" AutoPostBack="true"
                                                                CssClass="form-control" placeholder="Search Category/Item.." Width="200px">
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>
                                                                Search From BarCode
                                                            </label>
                                                            <asp:TextBox ID="txtbarcode" runat="server" OnTextChanged="search_barcode" AutoPostBack="true"
                                                                CssClass="form-control" placeholder="Search Barcode." Width="200px">
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div runat="server" id="posdropdown" visible="false" class="col-lg-12">
                                                    <div runat="server" visible="false" id="sno" class="col-lg-2">
                                                        <label>
                                                            S.NO</label>
                                                        <asp:TextBox ID="txtmanualslno" TabIndex="1" runat="server" Width="100%" Text="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Search From Item Master
                                                            </label>
                                                            <asp:DropDownList ID="drpitemsearch" runat="server" Visible="false"
                                                                Font-Bold="true"  OnSelectedIndexChanged="item_click" AutoPostBack="true"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                            <asp:UpdatePanel ID="upcus" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtCusName1" runat="server" Visible="false" Style="width: 415px; text-transform: uppercase;"
                                                                        Height="30px" placeholder="Enter Item Name"></asp:TextBox>
                                                                    <%--<ajaxToolkit:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement" DelimiterCharacters=""
                                                                Enabled="True" ServiceMethod="GetListofCustomer" MinimumPrefixLength="3" EnableCaching="true"
                                                                ServicePath="" TargetControlID="txtCusName1">
                                                            </ajaxToolkit:AutoCompleteExtender>--%>
                                                                    <asp:Label ID="NlblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                    <asp:HiddenField ID="NhideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                                    <asp:HiddenField ID="NhideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                                    <asp:HiddenField ID="NhideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                                    <asp:HiddenField ID="NhdRate" runat="server" Value='<%#Eval("Rate") %>' />
                                                                    <asp:HiddenField ID="NhdGST" runat="server" Value='<%#Eval("GST") %>' />
                                                                    <asp:Label ID="NlblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                                    <asp:Label ID="Nlblrate" runat="server" Text='<%#Eval("MRP") %>'></asp:Label>
                                                                    <asp:Label ID="Nlbqty" runat="server" Width="50px" Text='<%#Eval("Qty") %>'></asp:Label>
                                                                    <asp:Label ID="Nlblom" runat="server" Width="50px" Text='<%#Eval("UOM") %>'></asp:Label>
                                                                    <asp:Label ID="Nlblbarcode" runat="server" Width="50px" Text='<%#Eval("barcode") %>'></asp:Label>

                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="txtCusName1" EventName="TextChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <label>
                                                                Enter Qty
                                                            </label>
                                                            <asp:TextBox ID="txtqty" runat="server" OnTextChanged="txtqty_changed" AutoPostBack="true">
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divid" runat="server" style="height: 370px; overflow-x: auto;">
                                                    <label id="lblcap" runat="server">
                                                        Selected Category Items</label>
                                                    <div class="table-responsive panel-grid-left">
                                                        <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="false" CssClass="table table-striped pos-table" OnRowDataBound="onrowdatabound"
                                                            Width="100%" padding="0" spacing="0" border="0">
                                                            <%--HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                                        <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                                        <asp:HiddenField ID="hideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Serial No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbarcode" runat="server" Text='<%#Eval("serial") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Item">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("printitem") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Available Qty">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAvailable_Qty" runat="server" Width="50px" Text='<%#Eval("Available_Qty") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Qty">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQty" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server"
                                                                            Width="50px" AutoPostBack="false">0</asp:TextBox>
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
                                                            <%-- <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                            <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                            <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                            <%--  <HeaderStyle BackColor="#428bca" ForeColor="White" HorizontalAlign="Center" />--%>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <label id="Label1" runat="server">
                                                    Selected Requested Item List</label>
                                                <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gvqueueitems" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped pos-table"
                                                        padding="0" spacing="0" border="0" OnRowCommand="gvqueueitems_RowCommand" OnRowDeleting="gvqueueitems_RowDeleting">
                                                        <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                                    <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                                    <asp:HiddenField ID="hideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Serial No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblbarcode" runat="server" Text='<%#Eval("Barcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Available Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAvailable_Qty" runat="server" Width="50px" Text='<%#Eval("Available_Qty") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQty" runat="server" Width="50px" Text='<%#Eval("Qty") %>' Enabled="false">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblom" runat="server" Width="50px" Text='<%#Eval("UOM") %>'></asp:Label>
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
                                                        <%-- <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#428bca" ForeColor="White" HorizontalAlign="Center" />--%>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvUserInfo" runat="server">
                            <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                        </asp:GridView>
                    </div>
                    <div class="loading" align="center">
                        Loading. Please wait.<br />
                        <br />
                        <img src="../images/Preloader_10.gif" alt="" />
                    </div>
                    <script type="text/javascript" src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                    <script type="text/javascript" src="../css/select2.js"></script>
                    <link href="../css/select2.css" rel="stylesheet" />
                    <script type="text/javascript">
                        $(document).ready(function () { $("#drpitemsearch").select2(); });
                    </script>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
