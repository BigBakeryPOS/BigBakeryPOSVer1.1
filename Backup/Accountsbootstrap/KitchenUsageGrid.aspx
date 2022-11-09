<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitchenUsageGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.KitchenUsageGrid" %>

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
    <title>Kitchen Usage grid</title>
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
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
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
    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
        ID="val1" ShowMessageBox="true" ShowSummary="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div class="col-lg-12">
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center; font-size: large">
                Kitchen Usage Entry
            </div>
            <div class="col-lg-2">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="val1"
                    Style="color: White" InitialValue="0" ControlToValidate="ddlfilter" ValueToCompare="0"
                    Text="*" Operator="NotEqual" Type="String" ErrorMessage="Please Select Search By"></asp:CompareValidator>
                <asp:DropDownList Visible="false" CssClass="form-control" ID="ddlfilter" Style="width: 150px;
                    margin-left: 10px;" runat="server">
                    <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Bank Name" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Mobile No" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                    ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                    placeholder="Search Text" Style="width: 150px; margin-left: -20px;"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                    FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" "
                    TargetControlID="txtsearch" />
            </div>
            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
            <div class="col-lg-2 col-lg-offset-1">
                <asp:Button ID="btnsearch" Visible="false" runat="server" class="btn btn-success"
                    Text="Search" OnClick="Search_Click" Style="width: 120px; margin-left: -50px;
                    margin-top: 20px" ValidationGroup="val1" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnrefresh" runat="server" class="btn btn-primary" Visible="false"
                    Text="Reset" OnClick="refresh_Click" Style="width: 100px; margin-left: 20px;
                    margin-top: 20px" />
            </div>
            <div>
                <asp:Button ID="Button3" runat="server" class="btn btn-success" Text="Bulk Addition"
                    Visible="false" Style="width: 120px; margin-left: -45px; margin-top: 23px" Height="32px"
                    OnClick="btnFormat_Click" /></div>
            <div>
                <asp:Button ID="btnadd" runat="server" class="btn btn-danger" Text="Add New" OnClick="Add_Click"
                    Style="width: 120px; margin-right: 450px; margin-top: 20px" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnexcel" runat="server" class="btn btn-info" Visible="false" Text="Export-To-Excel"
                    Style="width: 120px; margin-left: 305px; margin-top: -36px" Height="32px" OnClick="btnExcel_Click" /></div>
            <table class="table table-bordered table-striped">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="Div1" runat="server" style="overflow: auto; height: 350px">
                            <asp:GridView ID="BankGrid" runat="server" CssClass="myGridStyle1" Width="100%" AllowSorting="true"
                                EmptyDataText="No Records Found" AutoGenerateColumns="false" OnRowCommand="BankGrid_RowCommand"
                                OnPageIndexChanging="BankGrid_PageIndexChanging1">
                                <HeaderStyle BackColor="#3366FF" />
                                <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:BoundField HeaderText="LedgerID" DataField="Purchaseid" Visible="false" />
                                    <asp:BoundField HeaderText="BillNo" DataField="BillNo" />
                                    <asp:BoundField HeaderText="BillDate" DataField="BillDate" />
                                    <asp:BoundField HeaderText="Name" DataField="Name" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="KitchenType" DataField="KitchenType" />
                                    <asp:BoundField HeaderText="Total" DataField="Total" Visible="false" />
                                    <asp:BoundField HeaderText="Paymen" DataField="Paymentmode" Visible="false" />
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="center" Visible="true">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Purchaseid") %>'
                                                CommandName="edit">
                                                <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png"  width="55px"/></asp:LinkButton>
                                            <asp:ImageButton ID="imgdisable" ImageUrl="~/images/edit.png" width="55px" runat="server" Visible="false"
                                                Enabled="false" ToolTip="Not Allow To Delete" />
                                            <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("Purchaseid") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("Purchaseid") %>'
                                                CommandName="delete" OnClientClick="alertMessage()">
                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/DeleteIcon_btn.png" /></asp:LinkButton>
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
                                </Columns>
                                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
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
