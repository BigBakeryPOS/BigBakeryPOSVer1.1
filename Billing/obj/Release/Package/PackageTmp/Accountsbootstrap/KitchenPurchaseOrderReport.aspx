<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitchenPurchaseOrderReport.aspx.cs" Inherits="Billing.Accountsbootstrap.KitchenPurchaseOrderReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <style type="text/css">
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#container {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 50%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
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
    <title>Purchase Order Report</title>
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

    <script type="text/javascript">
         function printGrid() {
             var gridData = document.getElementById('<%= BankGrid.ClientID %>');
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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1">
        <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
            ID="val1" ShowMessageBox="true" ShowSummary="false" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">Purchase Order Report</h1>
                        </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-3">

                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                                                ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                                            <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                                placeholder="Search Text"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                TargetControlID="txtsearch" />

                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                From date</label>
                                            <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                                OnTextChanged="txtfromdate_TextChanged"> 
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>

                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                To date</label>
                                            <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" AutoPostBack="true"
                                                OnTextChanged="txtfromdate_TextChanged">
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>

                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                Supplier</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlsuplier" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged" runat="server">
                                            </asp:DropDownList>

                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <label>
                                                Select Company</label>
                                            <asp:DropDownList ID="drpsubcompany" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged" TabIndex="1" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                RawMaterials</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlraw" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged" MaxLength="150" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-lg-3">

                                            <br />
                                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-info pos-btn1"
                                                Text="Print" OnClick="btnPrintFromCodeBehind_Click" Width="100px" />
                                            &nbsp;&nbsp;&nbsp; 
                                            <asp:Button ID="btnpdf" runat="server" Text="PDF" CssClass="btn btn-info" OnClick="btnpdf_Click" Width="100px" />

                                        </div>
                                        <div id="Div2" class="col-lg-1" runat="server" visible="false">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="btnExport" Text="Export to Excel" runat="server" Width="110px" CssClass="btn btn-success"
                                                    OnClick="btnExport_Click" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">

                                <div class="col-lg-12">

                                    <div id="Div1" runat="server" class="table-responsive panel-grid-left">
                                        <asp:GridView ID="BankGrid" runat="server" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0" Width="100%" AllowSorting="true"
                                            EmptyDataText="No Records Found" AutoGenerateColumns="false">
                                            <PagerStyle CssClass="pos-paging" />
                                            <%-- <HeaderStyle BackColor="#3366FF" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <Columns>
                                                <asp:BoundField HeaderText="CompanyName" DataField="compname" />
                                                <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                                                <asp:BoundField HeaderText="SupplierName" DataField="CustomerName" HeaderStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                <%-- <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />--%>
                                                <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Payment" DataField="Paymentmode" />
                                            </Columns>
                                            <%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript">            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>

                        <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
                            runat="server">
                            <div class="popup_Container">
                                <div class="popup_Titlebar" id="PopupHeader">
                                    <div class="TitlebarLeft">
                                        Customer List
                                    </div>
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
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
