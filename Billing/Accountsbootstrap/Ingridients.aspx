<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingridients.aspx.cs" Inherits="Billing.Accountsbootstrap.Ingridients" %>

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
    <title>Ingridients Grid </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
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
</head>
<body style="background-color: ">
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
        <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-8">
                        <div class="row panel-custom1">
                            <div class="panel-header">
                                <h1 class="page-header">Ingridients Masterr</h1>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group has-feedback">
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Search Ingredient.."
                                                onkeyup="Search_Gridview(this, 'Ingredientdrid')" CssClass="form-control">
                                            </asp:TextBox>
                                            <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                        </div>

                                        <label>
                                            Upload Data From Excel
                                        </label>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Style="display: inline" Width="50%" />
                                                <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                    OnClick="Async_Upload_File" />
                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload_File" CssClass="btn btn-danger pos-btn1" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:Button ID="btnReset" runat="server" Width="150px" class="btn btn-secondary" Text="Reset"
                                            OnClick="btnReset_Click" />
                                    </div>


                                    <div class="col-lg-12">

                                        <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="Ingredientdrid" runat="server" PagerStyle-CssClass="pager" CssClass="table table-striped pos-table"
                                                ShowHeader="true" Width="100%" AutoGenerateColumns="False" OnRowCommand="Ingredientdrid_RowCommand" padding="0" spacing="0" border="0">
                                                <AlternatingRowStyle></AlternatingRowStyle>
                                                <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                                <Columns>
                                                    <asp:BoundField DataField="IngridID" HeaderText="ID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                    <asp:BoundField DataField="IngreCategory" HeaderText="Ingr.Category" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="IngredientCode" HeaderText="Ingr.Code" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="IngredientName" HeaderText="IngredientName" ItemStyle-Width="250px" />
                                                    <asp:BoundField DataField="UOM" HeaderText="UOM" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="hsncode" HeaderText="HSNCODE" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="Quantity" HeaderText="Min.Qty" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="TaxValue" HeaderText="Tax" ItemStyle-Width="100px" />
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandName="et" CommandArgument='<%#Eval("IngridID") %>' CssClass="btn btn-warning btn-md"
                                                                runat="server">
                                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" Visible="false" />
                                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndel" CommandName="Dl" CommandArgument='<%#Eval("IngridID") %>'
                                                                runat="server">
                                                                <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" Visible="false" />
                                                                <button type="button" class="btn btn-danger btn-md">
                                                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                                </button>
                                                            </asp:LinkButton>
                                                            <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndel"
                                                                PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                            </ajaxToolkit:ModalPopupExtender>
                                                            <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                TargetControlID="btndel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <%-- <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                <PagerStyle CssClass="pgr"></PagerStyle>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="row panel-custom1">
                            <%--           <blink> <label  style="color:Green; font-size:12px">Please Fill Ingredient Details  </label></blink>--%>
                            <div class="panel-header">
                                <h1 class="page-header">Add Ingredient</h1>
                            </div>

                            <div class="panel-body panel-form-right">
                                <div class="list-group">
                                    <label>
                                        Select Ingredient Category</label>
                                    <asp:DropDownList ID="ddlIngreCategory" runat="server" CssClass="form-control" Visible="true">
                                    </asp:DropDownList>
                                    <br />
                                    <label>
                                        Ingredient Name</label>
                                    <asp:TextBox ID="txtingre" runat="server" placeholder="Enter Ingredient Name" CssClass="form-control"></asp:TextBox><br />
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <label>
                                                Ingredient Code</label>
                                            <asp:TextBox ID="txtingreCode" runat="server" placeholder="Enter Ingredient Code"
                                                CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                        <div class="col-lg-6">
                                            <label>
                                                HSN Code</label>
                                            <asp:TextBox ID="txthsncode" runat="server" placeholder="Enter HSN Code"
                                                CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <label>
                                                Minimum Quantity</label>
                                            <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter Minimum Quantity"
                                                CssClass="form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                                FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtQuantity" />
                                        </div>
                                        <div class="col-lg-6">
                                            <label>
                                                Buffer Quantity</label>
                                            <asp:TextBox ID="txtbufferqty" runat="server" placeholder="Enter Buffer Quantity"
                                                CssClass="form-control"></asp:TextBox><br />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtbufferqty" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <label>
                                                UOM</label>
                                            <asp:DropDownList ID="ddlunits" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <br />
                                        </div>
                                        <div class="col-lg-6">
                                            <label>
                                                Tax</label>
                                            <asp:DropDownList ID="ddltax" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <br />
                                        </div>
                                    </div>
                                    <asp:CheckBox ID="chkallow" runat="server" />
                                    <label>Allow Request</label>
                                    <br />
                                    <br />
                                    <asp:CheckBoxList ID="chkprimaryuom" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" ></asp:CheckBoxList>

                                    <br />
                                    <br />

                                    <asp:Button ID="btnSubmit" Width="150px" runat="server"
                                        class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnadd_Click" />
                                    <asp:Button ID="btnclaear" Width="150px" runat="server"
                                        class="btn btn-lg btn-link" Text="Clear" OnClick="btncancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none; background-color: #c7c7c7"
        runat="server">
        <div class="popup_Container">
            <div style="background-color: #2cbcf0; height: 30px" id="PopupHeader">
                <div align="center" style="color: White; font-weight: bold" class="TitlebarLeft">
                    Warning Message!!!
                </div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div align="center" style="color: Black; font-size: medium" class="">
                <p>
                    Are you sure want to Delete
                    <label id="lblpop" runat="server">
                    </label>
                    ?
                </p>
            </div>
            <div align="center" class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" class="btn btn-success" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" class="btn btn-danger" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
