<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tax.aspx.cs" Inherits="Billing.Accountsbootstrap.Tax" %>


<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Tax Grid </title>
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
        function requiredValue(inputtxt) 
        {
            
            var numbers = /^[0-9]+$/;
            alert(inputtxt);
            if (this.val().)) {
            }
            else {
                alert('Please input numeric characters only');                
                return false;
            }
            
        }      </script>
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
            50% { opacity: 0; }
       }
      </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   
    <form id="f1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <div class="container-fluid">
	        <div class="row">
            <div class="col-lg-12" >
             <div class="col-lg-8">
                <div class="row panel-custom1">
                    <div class="panel-header">
                      <h1 class="page-header">Tax Master</h1>
	                </div>
                    <div class="panel-body">
                        <div class="row">
                                <div class="col-lg-4">
                                 <div class="form-group has-feedback">
                                    <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" onkeyup="Search_Gridview(this, 'gv')"
                                        placeholder="Search Tax.." ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" -"
                                        TargetControlID="txtsearch" />
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                  </div>
                                </div>
                                <div class="col-lg-8 text-left">
                                    <asp:Button ID="btnresret" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Btn_Reset"
                                        Width="150px" />
                                 </div>

                            <div class="col-lg-12">
                     <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gv" runat="server" DataKeyNames="TaxID" OnRowCommand="edit" Width="100%" cssClass="table table-striped pos-table"
                                            EmptyDataText="Oops! No Activity Performed." AutoGenerateColumns="false" padding="0" spacing="0" border="0" >
                                             <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" />--%> 
                                            <Columns>
                                                <asp:BoundField HeaderText="TaxID" DataField="Taxid" Visible="false" />
                                                <asp:BoundField HeaderText="Tax" DataField="TaxName" />
                                                <asp:TemplateField  HeaderText="Edit" Visible="true" ItemStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("TaxID") %>' CommandName="EditRow" cssclass="btn btn-warning btn-md"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px" Visible="false"/>
                                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                        </asp:LinkButton>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("TaxID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("TaxID") %>' CommandName="Del"
                                                            runat="server">
                                                            <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" Visible="false" />
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
                               
                                    
                                </div></div></div> 
                </div>
             <div class="col-lg-4">
                                    <div class="panel panel-custom1">
                                     <%--   <blink> <label  style="color:Green; font-size:12px">Please Fill Tax </label></blink>--%>
                                       <div class="panel-header">
				                                <h1 class="page-header">Add Tax</h1>
		                                </div>
                                        <div class="panel-body panel-form-right">
                                            <div class="list-group">
                                                <asp:TextBox ID="txtid" Visible="false" runat="server"></asp:TextBox>
                                                <label>Tax</label>
                                                <asp:TextBox placeholder="Enter Tax" ID="txtTax" runat="server" 
                                                    CssClass="form-control" onkeyup="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" AutoPostBack="false"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ./\!@#$%^&*,"
                                                    TargetControlID="txtTax" />
                                                <br />
                                                <asp:DropDownList ID="ddlIsActive" runat="server" class="form-control" Visible="false">
                                                    <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                                <div id="showtxt" runat="server" visible="false">
                                                    <label>Edit Narrations</label>
                                                    <asp:TextBox placeholder="Enter Narrations" ID="txtnarration" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnSubmit" Style="width: 150px; margin-left: 0px;" runat="server"
                                                    class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnclaear" Style="width: 150px; margin-left: 1px;" runat="server"
                                                    class="btn btn-link" Text="Clear" OnClick="btncancel_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
            </div>
            </div>
            </div>
                    
                  
      
    </form>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Category List</div>
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
</body>
</html>
