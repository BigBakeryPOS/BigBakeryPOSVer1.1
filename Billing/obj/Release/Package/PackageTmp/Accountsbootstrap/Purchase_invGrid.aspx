<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_invGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Purchase_invGrid" %>

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
    <title>Purchase Grid Master - bootsrap</title>
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
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 550px;
            width: 600px;
            padding: 3px;
            border: solid 1px black;
        }
    </style>
    <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();

            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
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
        $(document).ready(function () {

            //         Client Side Search (Autocomplete)
            //         Get the search Key from the TextBox
            //         Iterate through the 1st Column.
            //         td:nth-child(1) - Filters only the 1st Column
            //         If there is a match show the row [$(this).parent() gives the Row]
            //         Else hide the row [$(this).parent() gives the Row]

            $('#txtsearch').keyup(function (event) {
                var searchKey = $(this).val().toLowerCase();
                $("#BankGrid tr td:nth-child(1)").each(function () {
                    var cellText = $(this).text().toLowerCase();
                    if (cellText.indexOf(searchKey) >= 0) {
                        $(this).parent().show();
                    }
                    else {
                        $(this).parent().hide();
                    }
                });
            });
        });

    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">Purchase Entry
           <span class="pull-right">
               <asp:LinkButton ID="addbtn" runat="server" OnClick="Add_Click">
             <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
               </asp:LinkButton>
           </span>
                            </h1>
                        </div>

                        <div class="panel-body">

                            <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                ID="val1" ShowMessageBox="true" ShowSummary="false" />
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="row">
                                <div class="col-lg-3">

                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                                        ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                                    <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                        placeholder="Search Text if Date  Fill Format dd/MM/yyyy"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" /"
                                        TargetControlID="txtsearch" />

                                </div>

                                <div id="Div2" runat="server" class="col-lg-3">
                                    <label>Search Type</label>
                                    <asp:DropDownList ID="drpsearchlist" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="DC No" Value="kp.dcNO"></asp:ListItem>
                                        <asp:ListItem Text="Bill No" Value="kp.BillNo"></asp:ListItem>
                                        <asp:ListItem Text="DC Date" Value="kp.billdate"></asp:ListItem>
                                        <asp:ListItem Text="Supplier Name" Value="c.ledgername"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div id="Div3" runat="server" visible="true" class="col-lg-3">

                                    <label>From date</label>
                                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                        OnTextChanged="txtfromdate_TextChanged"> 
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-lg-3 ">
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
                                    <asp:DropDownList CssClass=" form-control" ID="ddlsuplier"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>

                                <div class="col-lg-3 ">
                                    <br />
                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-info  pos-btn1" Text="Search" OnClick="Search_Click" />

                                    &nbsp;&nbsp;&nbsp;     
                                    <asp:Button ID="Button1" runat="server" class="btn btn-secondary" Text="Reset" PostBackUrl="~/Accountsbootstrap/Purchase_invGrid.aspx" />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">

                                    <div id="Div1" runat="server" class="table-responsive panel-grid-left">
                                        <asp:GridView ID="BankGrid" runat="server" Width="100%" AllowSorting="true" CssClass="table table-striped pos-table"
                                            EmptyDataText="No Records Found" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                            OnRowCommand="BankGrid_RowCommand">
                                            <%-- <HeaderStyle BackColor="#3366FF" />--%>
                                            <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <Columns>
                                                <asp:BoundField HeaderText="LedgerID" DataField="Purchaseid" Visible="false" />
                                                <asp:BoundField HeaderText="Invoice No" DataField="dcNo" />
                                                <asp:BoundField HeaderText="DC Date" DataField="BillDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="DC No" DataField="BillNo" />
                                                <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="SupplierName" DataField="CustomerName" HeaderStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Payment" DataField="Paymentmode" />
                                                <asp:TemplateField HeaderText="Print" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnPrint" runat="server" CommandArgument='<%#Eval("purchaseID") %>'
                                                            CommandName="Print">
                                                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/print%20(1).png" Width="55px" Visible="false" />
                                                            <button type="button" class="btn btn-default btn-md">
                                                                <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
                                                            </button>
                                                        </asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable2" ImageUrl="~/images/edit.png" runat="server" Visible="false" Width="55px"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("BillNo") %>'
                                                            CommandName="edit">
                                                            <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png" Width="55px" Visible="false" />
                                                            <button type="button" class="btn btn-warning btn-md">
                                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </button>
                                                        </asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable" ImageUrl="~/images/edit.png" Width="55px" runat="server" Visible="false"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("BillNo") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("purchaseid") %>'
                                                            CommandName="delete" OnClientClick="alertMessage()">
                                                            <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" Visible="false" />
                                                            <button type="button" class="btn btn-danger btn-md">
                                                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                            </button>
                                                        </asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable1" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="5%" HeaderText="Preview Image">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("invupload1")%>'
                                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                                        <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("invupload2")%>'
                                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("invupload3")%>'
                                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <%--<HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>

                                    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
                                    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                                    <script type="text/javascript">                            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                                </div>
                            </div>
                            <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
                                runat="server">
                                <div class="popup_Container">
                                    <div class="popup_Titlebar" id="PopupHeader">
                                        <div class="TitlebarLeft">
                                            Delete Purchase Invoice
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
            <div id="divBackground">
            </div>
            <div id="divImage">
                <table style="height: 100%; width: 100%">
                    <tr>
                        <td valign="middle" align="center">
                            <img id="imgLoader" alt="" src="images/loader.gif" />
                            <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="bottom">
                            <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
