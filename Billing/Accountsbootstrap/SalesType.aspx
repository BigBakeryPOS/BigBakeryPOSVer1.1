<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesType.aspx.cs" Inherits="Billing.Accountsbootstrap.SalesType" %>

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
    <title>SalesType Grid </title>
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
                                <h1 class="page-header">Sales Type Master</h1>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group has-feedback">
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Search Sales Type.."
                                                onkeyup="Search_Gridview(this, 'Ingredientdrid')" CssClass="form-control"></asp:TextBox>
                                            <span class="glyphicon glyphicon-search form-control-feedback"></span>

                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:Button ID="btnReset" runat="server" Width="150px" class="btn btn-secondary" Text="Reset"
                                            OnClick="btnReset_Click" />
                                    </div>

                                    <div class="col-lg-12">

                                        <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="Ingredientdrid" runat="server" PagerStyle-CssClass="pager" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                ShowHeader="true" Width="100%" AutoGenerateColumns="False"
                                                OnRowCommand="Ingredientdrid_RowCommand">
                                                <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>

                                                <Columns>
                                                    <asp:BoundField DataField="SalesTypeID" HeaderText="ID" ItemStyle-CssClass="hide"
                                                        HeaderStyle-CssClass="hide" />
                                                    <asp:BoundField DataField="PaymentType" HeaderText="Payment Type" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="Margin" HeaderText="Margin" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="GST" Visible="true" HeaderText="GST" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="PaymentGatway" HeaderText="Payment Gatway" ItemStyle-HorizontalAlign="center"
                                                        HeaderStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" ItemStyle-HorizontalAlign="left" />
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandName="et" CssClass="btn btn-warning btn-md" CommandArgument='<%#Eval("SalesTypeID") %>'
                                                                runat="server">
                                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" Width="55px" runat="server" Visible="false" />
                                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndel" CommandName="Dl" CommandArgument='<%#Eval("SalesTypeID") %>'
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
                        <div class="panel panel-custom1">
                            <%--           <blink> <label  style="color:Green; font-size:12px">Please Fill Ingredient Details  </label></blink>--%>
                            <div class="panel-header">
                                <h1 class="page-header">Add SalesType</h1>
                            </div>
                            <div class="panel-body panel-form-right">
                                <div class="list-group">
                                    <label>Select Bill Type Name</label>
                                    <asp:DropDownList ID="drpbilltype" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <br />
                                    <label>Payment Type Name</label>
                                    <asp:TextBox ID="txtpaytype" runat="server" placeholder="Enter Payment Type Name" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <div runat="server" visible="false">
                                        <label>Margin/Commission</label>
                                        <asp:TextBox ID="txtmargin" Text="0" runat="server" placeholder="Enter Margin" CssClass="form-control" OnTextChanged="Totcalcmar" AutoPostBack="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtmargin" />
                                        <br />
                                        <label>GST % : (Commission/Margin)</label>
                                        <asp:TextBox Visible="true" Text="0" ID="txtGST" runat="server" placeholder="Enter GST For Commission/Margin" CssClass="form-control" Enabled="true" OnTextChanged="Totcalc" AutoPostBack="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                            FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtGST" />
                                        <br />
                                        <label>Payment Gateway</label>
                                        <asp:TextBox ID="txtPayGatway" Text="0" runat="server" placeholder="Enter Payment Gateway" OnTextChanged="Totcalc" AutoPostBack="true"
                                            CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtPayGatway" />
                                        <br />
                                        <label>Total</label>
                                        <asp:TextBox ID="txtTotal" Text="0" runat="server" placeholder="Enter txtTotal" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtTotal" />
                                        <br />
                                    </div>
                                    <label>IsActive</label>
                                    <asp:DropDownList ID="ddIsActive" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="YES" Value="YES" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <div runat="server" visible="false">
                                        <label>Is Inclusive Of Rate </label>
                                        <asp:CheckBox ID="chkinclusiverate" runat="server" Width="20px" />
                                    </div>

                                    <label>Is Normal Bill</label>
                                    <asp:CheckBox ID="chknormalbill" runat="server" Width="20px" />
                                    <label>Is Overall Discount</label>
                                    <asp:CheckBox ID="chkoveralldiscount" runat="server"
                                        OnCheckedChanged="chk_discountcnaged" AutoPostBack="true" Width="20px" />



                                    <label>Is Discount</label>
                                    <asp:CheckBox ID="chkdiscountchk" runat="server" OnCheckedChanged="chk_discountcnaged1" AutoPostBack="true" Width="20px" />

                                    <br />

                                    <br />
                                    <label>Order Count</label>
                                    <asp:TextBox ID="txtordercount" runat="server" placeholder="Enter Order Count" CssClass="form-control" Text="0" Enabled="true"></asp:TextBox>
                                    <br />
                                    <label>Order Type</label>
                                    <asp:DropDownList ID="drpordertype" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Only Number" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Both Number & Alphabetics" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <div id="divchk" runat="server" visible="false">
                                        <label>Disc Attender</label>
                                        <asp:DropDownList ID="drpdiscattender" runat="server" CssClass="form-control" OnSelectedIndexChanged="attender_discChnaged" AutoPostBack="true"></asp:DropDownList><br />
                                        <label>Password</label>
                                        <asp:Label ID="lblpassword" runat="server" CssClass="form-control"></asp:Label><br />
                                        <label>Disc Percentage</label>
                                        <asp:DropDownList ID="drpdiscpper" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <label>Payment Mode Selection</label>
                                    <asp:CheckBoxList ID="chkpaylist" runat="server" RepeatColumns="4"></asp:CheckBoxList>
                                </div>
                                <asp:Button ID="btnSubmit" Style="width: 150px;" runat="server"
                                    class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnadd_Click" />
                                <asp:Button ID="btnclaear" Style="width: 150px;" runat="server"
                                    class="btn btn-lg btn-link" Text="Clear" OnClick="btncancel_Click" />
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
