<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestStockSettings.aspx.cs"
    Inherits="Billing.Accountsbootstrap.RequestStockSettings" %>

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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Request Stock Settings </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
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
    <style>
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
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
    <link href="../Styles/chosen.css" rel="Stylesheet" />
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
</head>
<body style="font-family: Calibri; font-size: medium;">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Request Stock Settings</b></div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <asp:TextBox CssClass="form-control" ID="txtsearch" placeholder="Search Category.."
                                onkeyup="Search_Gridview(this, 'gridview')" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                            <asp:Label ID="lblerror" runat="server" Style="color: Red" visible="false"></asp:Label>
                        </div>
                        <div class="col-lg-6">
                         <label id="lblrequeststockid" visible="false" runat="server" />
                            <asp:Button ID="btnresret" runat="server" class="btn btn-warning" Text="Reset"
                                Width="100px" />
                            <%-- <asp:DropDownList ID="drptype" runat="server" Visible="false" CssClass="form-control" >
                                        <asp:ListItem Text="Fetching Old/New Category" Value="1" Selected="True" ></asp:ListItem>
                                        <asp:ListItem Text="Fetching New Category" Value="2" ></asp:ListItem>
                                        </asp:DropDownList>--%>
                         </div>
                    </div>
                    <div class="col-lg-12">
                        <br />
                        <div style="height: 350px; overflow: scroll">
                            <asp:GridView ID="gridview" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                Width="100%" Font-Names="Calibri" AllowSorting="true" OnRowCommand="gvcat_RowCommand"
                                OnSorting="gridview_Sorting" OnRowEditing="gridview_RowEditing">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />
                                <Columns>
                                   <asp:BoundField HeaderText="RequestStockId" DataField="RequestStockId" />
                                    <asp:BoundField HeaderText="From Time" DataField="FromTime" DataFormatString="{0:T}"/>
                                      <asp:BoundField HeaderText="To Time" DataField="Totime" DataFormatString="{0:T}"/>
                                    <asp:BoundField HeaderText="Daley Days" DataField="Delaydays" />
                                  
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandArgument='<%#Eval("RequestStockId") %>'
                                                CommandName="Edit" runat="server">
                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("RequestStockId") %>' CommandName="Del"
                                                runat="server">
                                                <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
                                            <asp:ImageButton ID="imgdisable1321" ImageUrl="~/images/delete.png" runat="server"
                                                Visible="false" Enabled="false" ToolTip="Not Allow To Delete" />
                                            <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndel"
                                                PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                            </ajaxToolkit:ModalPopupExtender>
                                            <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                TargetControlID="btndel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <blink> <label  style="color:Green; font-size:12px">Request Stock Settings Create</label></blink>
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Request Stock Settings Create</b></div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="col-lg-7">

                            <div class="form-group">
                                <label>
                                    From Time
                                </label>
                                <asp:DropDownList ID="ddlTimeFrom" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="fromtime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                                    Visible="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label>
                                    TO Time</label>
                                <asp:DropDownList ID="ddlTimeTo" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="totime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                                    Visible="false"></asp:Label>
                            </div>

                              <div class="form-group">
                                <label>
                                    Delay Days</label>
                                <asp:TextBox ID="txtdelayday" CssClass="form-control" runat="server">
                                </asp:TextBox>
                            </div>
                            <asp:Button ID="btnSave" runat="server" class="btn btn-success" Text="Save" OnClick="btnSave_Click"
                                ValidationGroup="val1" AccessKey="s" Width="110px" />
                            <label>
                            </label>
                            <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click"
                                Width="110px" />
                        </div>
                        <div class="col-lg-3">
                        <asp:CheckBoxList ID="chkcategory" runat="server"></asp:CheckBoxList>

                         
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Request Stock Settings List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                    <blink> <label  style="color:Red; font-size:12px">If you Delete This Entry It Will Affect Your Branchs!!!</label> </blink>
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
