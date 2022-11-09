<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostingReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.CostingReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <link rel="stylesheet" type="text/css" href="css/mGrid.css" />
    <style type="text/css" re>
        .table-striped1 > tbody > tr:nth-child(even)
        {
            background-color: #81d8d0;
        }
        .table-striped1 > tbody > tr:nth-child(odd)
        {
            background-color: #81d8d0;
        }
        /* Background Gradient for Analagous Colors */
        .gradient2
        {
            background-color: #08D0AA; /* For WebKit (Safari, Chrome, etc) */
            background: #08D0AA -webkit-gradient(linear, left top, left bottom, from(#0871D0), to(#08D0AA)) no-repeat; /* Mozilla,Firefox/Gecko */
            background: #08D0AA -moz-linear-gradient(top, #0871D0, #08D0AA) no-repeat; /* IE 5.5 - 7 */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#08D0AA) no-repeat; /* IE 8 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#0871D0)" no-repeat;
        }
    </style>
    <script type="text/javascript">
        function Denomination() {


            var gridData = document.getElementById('gridcatqty1');



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
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Costing Report</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
        .messagepop
        {
            border: 1px solid #999999;
            cursor: default;
            display: none;
            margin-top: 15px;
            position: absolute;
            text-align: left;
            width: 394px;
            height: 100px;
            z-index: 50;
            padding: 25px 25px 20px;
            border-radius: 7px;
            background: #e84c3d;
            margin: 30px auto 0;
            padding: 6px;
            color: White;
            top: 50%;
            left: 50%;
            margin-left: -400px;
            margin-top: -40px;
        }
    </style>
    <script language="javascript">
        function shw() {
            var sub = document.getElementById("popup");
            sub.style.display = 'block';
        }

       
    </script>
    <script>
        function klose() {
            var sub = document.getElementById("popup");

            sub.style.display = 'none';

        }
    </script>
    <script language="javascript">


        function hide() {
            var sub = document.getElementById("popup");
            if (document.getElementById("txtnam").value == "") {
                alert('Pleae enter your name');
            }
            else {

                sub.style.display = 'none';
            }
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
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
        }
    </script>
    <script type="text/javascript">
        function alertMessage() {
            alert('Email Sent Sucessfully !');
        }



    </script>
    <script type="text/javascript">
        function Closed() {
            alert('Thank You !');
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="panel panel-default" style="">
                    <div class="panel-heading" style="background-color: #0071BD; color: White">
                        Costing Report</div>
                    <div class="panel panel-body">
                        <div class="col-lg-12">
                            <div class="col-lg-3">
                            </div>
                            <div class="col-lg-2">
                                Select Category:
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="chzn-select" Width="200px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                Select Item:
                                <asp:DropDownList ID="ddlitem" runat="server" CssClass="chzn-select" Width="200px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlitem_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-1">
                                <asp:Label ID="lblPrint" runat="server">Print</asp:Label><br />
                                <asp:Button ID="btn" runat="server" Text="Print" Visible="true" CssClass="btn btn-danger"
                                    OnClientClick="Denomination()" Width="100px" />
                            </div>
                            <div class="col-lg-1">
                            </div>
                            <div class="col-lg-3">
                            </div>
                        </div>
                        <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="col-lg-12" style="margin-top: 10px">
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextBox1" runat="server" onkeyup="Search_Gridview(this, 'gvitems')"
                                            placeholder=" Search  Items" CssClass="form-control" Width="100%"></asp:TextBox>
                                        <div id="gridcatqty1" runat="server" style="height: 370px; overflow-x: auto; margin-top: 10px">
                                            <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                Caption="Costing Details" EmptyDataText="No Record Found" OnRowDataBound="gvCustsales_RowDataBound"
                                                DataKeyNames="CategoryUserID">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                                    <asp:BoundField HeaderText="Items" DataField="Definition" />
                                                    <asp:TemplateField HeaderText="Price" Visible="true">
                                                        <ItemTemplate>
                                                            <label>
                                                                MRP</label><br />
                                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Rate","{0:0.00}") %>' Width="70px"></asp:Label>
                                                            <br />
                                                            <label>
                                                                GST</label><br />
                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("GST","{0:0.00}") %>' Width="70px"></asp:Label><br />
                                                            <label>
                                                                Amount</label><br />
                                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("PriceAmt","{0:0.00}") %>' Width="70px"></asp:Label><br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Values" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                            <label>
                                                                Prepared Qty</label><br />
                                                            <asp:TextBox ID="txtTotalQty" runat="server" Text='<%#Eval("TotalQty","{0:0.00}") %>'
                                                                Width="70px" AutoPostBack="true" OnTextChanged="txtTotalQty_OnTextChanged">0</asp:TextBox><br />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtTotalQty"
                                                                FilterType="Custom,Numbers" ValidChars="." />
                                                            <label>
                                                                Misc. Amount</label><br />
                                                            <asp:TextBox ID="txtmisc" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtTotalQty_OnTextChanged">0</asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                TargetControlID="txtmisc" FilterType="Custom,Numbers" ValidChars="." />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" HeaderText="Cost Details"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="javascript:switchViews('dv<%# Eval("CategoryUserID") %>', 'imdiv<%# Eval("CategoryUserID") %>');"
                                                                style="text-decoration: none;">
                                                                <img id="imdiv<%# Eval("CategoryUserID") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                            </a>
                                                            <%# Eval("Cost")%>
                                                            <asp:GridView runat="server" ID="gvitemcost" CssClass="myGridStyle" Width="100%"
                                                                GridLines="Both" OnRowDataBound="gvitemcost_RowDataBound" AutoGenerateColumns="false"
                                                                ShowFooter="true">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                                                                    <asp:BoundField HeaderText="RecQty" DataField="RecQty" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="UOM" DataField="UOM" />
                                                                    <asp:BoundField HeaderText="Rate" DataField="Rate" />
                                                                    <asp:BoundField HeaderText="Price" DataField="Price" DataFormatString='{0:f}' />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div id="dv<%# Eval("CategoryUserID") %>" style="display: none; position: relative;">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>
                                            Apply Prepared Qty to all Items</label>
                                        <asp:TextBox ID="txtPreparedQty" runat="server" placeholder=" Apply Prepared Qty to all Items" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtTotalQty_OnTextChanged"
                                            Width="100%">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtPreparedQty"
                                            FilterType="Custom,Numbers" ValidChars="." />
                                        <label>
                                            Apply Misc. Amount to all Items</label>
                                        <asp:TextBox ID="txtMiscAmount" runat="server" placeholder="  Apply Misc. Amount to all Items" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtTotalQty_OnTextChanged"
                                            Width="100%">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            TargetControlID="txtMiscAmount" FilterType="Custom,Numbers" ValidChars="." />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    </form>
</body>
</html>
