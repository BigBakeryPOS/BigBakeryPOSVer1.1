<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterBranchSetting.aspx.cs"
    Inherits="Billing.Accountsbootstrap.InterBranchSetting" %>

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
    <title>Inter Branch Setting Details </title>
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
    <style type="text/css">
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
     <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-8">
            <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Inter Branch Setting</h1>
	    </div>
                <div class="panel-body">
                    <div class="row">
                        
                            <div class="col-lg-4">
                            <div class="form-group has-feedback">
                                <asp:TextBox CssClass="form-control" placeholder="Search Details.. " ID="txtsearch"
                                    onkeyup="Search_Gridview(this, 'gridview')" runat="server" MaxLength="50" ></asp:TextBox>
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                            </div>
                            <div class="col-lg-8">
                                <asp:Button ID="btnresret" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Btn_Reset"
                                    Width="150px" /></div>
                        
                    <div class="col-lg-12">
                    <div class="table-responsive panel-grid-left">
                        
                        <asp:GridView ID="gridview" runat="server" UseAccessibleHeader="true" cssClass="table table-striped pos-table"
                            AllowPaging="false" AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvcat_RowCommand" padding="0" spacing="0" border="0"
                            OnSorting="gridview_Sorting" OnRowDataBound="gridview_OnRowDataBound" OnRowEditing="gridview_RowEditing">
                           <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />--%>
                            <Columns>
                                <asp:BoundField HeaderText="Branch Name" DataField="branchname" />
                                <asp:BoundField HeaderText="Is Active" DataField="IsActive" />
                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" ForeColor="White" cssclass="btn btn-warning btn-md" CommandArgument='<%#Eval("Interid") %>'
                                            CommandName="Editt" runat="server">
                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" visible="false" width="55px"/>
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                            </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("Interid") %>' CommandName="Del"
                                            runat="server">
                                            <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" visible="false"/>
                                            <button type="button" class="btn btn-danger btn-md">
												<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
												</button>
                                                </asp:LinkButton>
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
        </div>
        <div class="col-lg-4">
         <div class="panel panel-custom1">
		<div class="panel-header">
				<h1 class="page-header">Add Inter Branch Setting</h1>
		</div>
                <div class="panel-body panel-form-right">
                    <div class="list-group">
                       
                            <asp:TextBox CssClass="form-control" ID="txtinterid" runat="server" Visible="false"></asp:TextBox>
                       
                            <label>
                                Store Branch</label>
                            <asp:DropDownList ID="drpstorebranch" runat="server" CssClass="form-control" OnSelectedIndexChanged="storebranchchange"
                                AutoPostBack="true">
                            </asp:DropDownList>
                      <br />
                            <label>
                                Inter Branch</label>
                            <asp:CheckBoxList ID="chkinterbranch" runat="server">
                            </asp:CheckBoxList>
                      <br />
                        <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnSave_Click"
                            ValidationGroup="val1" AccessKey="s" Width="150px" />
                        <label>
                        </label>
                        <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="Exit_Click"
                            Width="150px" />
                    </div>
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
                    Online List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                    <blink> <label  style="color:Red; font-size:12px">If you Delete This Inter Branch Setting It Will Affect Your Branchs or Your Production!!!</label> </blink>
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
