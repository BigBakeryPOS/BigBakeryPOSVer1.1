<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProduuctionStockDetails.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ProduuctionStockDetails" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <style type="text/css">
        a img
        {
            border: none;
        }
        ol li
        {
            list-style: decimal outside;
        }
        div#container
        {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }
        div.side-by-side
        {
            width: 100%;
            margin-bottom: 1em;
        }
        div.side-by-side > div
        {
            float: left;
            width: 50%;
        }
        div.side-by-side > div > em
        {
            margin-bottom: 10px;
            display: block;
        }
        .clearfix:after
        {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Production Raw Materials Detail</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            $find('modalpopup').hide();
            //$get('btnCancel').click();
        }
    </script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
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
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1">
    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
        ID="val1" ShowMessageBox="true" ShowSummary="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12">
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center; font-size: large">
                Production Raw Materials Detail</div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="col-lg-2">
                        <div class="form-group ">
                            <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                onkeyup="Search_Gridview(this, 'BankGrid')" placeholder="Search Items..." Style="width: 150px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-2 ">
                    </div>
                </div>
                <div class="col-lg-12">
                  
                            <div id="Div1" runat="server" style="overflow: auto; height: 350px">
                                <asp:GridView ID="BankGrid" runat="server" CssClass="mGrid" Width="100%" AllowSorting="true"
                                    EmptyDataText="No Records Found" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#3366FF" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                                        <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                                        <asp:BoundField HeaderText="Unit" DataField="UOM" />
                                    </Columns>
                                    <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                           
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
            </div>
        </div>
        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript">            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </div>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Customer List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                </p>
            </div>
            <div class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
