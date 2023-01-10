<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySettingsMaster.aspx.cs"
    Inherits="Billing.Accountsbootstrap.CategorySettingsMaster" %>

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
    <title>Category Settings Grid </title>
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
      <script type="text/javascript">
          function SearchEmployees(txtSearch, cblEmployees) {
              if ($(txtSearch).val() != "") {
                  var count = 0;
                  $(cblEmployees).children('tbody').children('tr').each(function () {
                      var match = false;
                      $(this).children('td').children('label').each(function () {
                          if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                              match = true;
                      });
                      if (match) {
                          $(this).show();
                          count++;
                      }
                      else { $(this).hide(); }
                  });
                  $('#spnCount').html((count) + ' match');
              }
              else {
                  $(cblEmployees).children('tbody').children('tr').each(function () {
                      $(this).show();
                  });
                  $('#spnCount').html('');
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
    <div class="col-lg-12">
        <div class="col-lg-8">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Category Settings Master</h1>
	    </div>

                <div class="panel-body">
                    <div class="row">
                       
                            <div class="col-lg-4">
                            <div class="form-group has-feedback">
                                <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" onkeyup="Search_Gridview(this, 'gv')"
                                    placeholder="Search Category Settings.." MaxLength="50" ></asp:TextBox>
                                    <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" -"
                                    TargetControlID="txtsearch" />
                            </div>
                            </div>
                            <div class="col-lg-8">
                                <asp:Button ID="btnresret" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Btn_Reset"
                                   /></div>
                       
                        <div class="col-lg-12">
                          
                           <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gv" runat="server" DataKeyNames="CatSettingsId" OnRowCommand="edit" Width="100%" cssClass="table table-striped pos-table"
                                    Font-Names="Calibri" EmptyDataText="Oops! No Activity Performed." AutoGenerateColumns="false" padding="0" spacing="0" border="0">
                                  <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="CatSettingsId" DataField="CatSettingsId" Visible="false" />
                                        <asp:BoundField HeaderText="CategoryId" DataField="CategoryId" />
                                          <asp:BoundField HeaderText="Category" DataField="Category" />
                                        <asp:TemplateField  HeaderText="Edit" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("CatSettingsId") %>' CommandName="EditRow"
                                                    runat="server">
                                                    <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" visible="false"/>
                                                    <button type="button" class="btn btn-warning btn-md">
						                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
					                                </button>
                                                </asp:LinkButton>
                                                <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("CatSettingsId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("CatSettingsId") %>' CommandName="Del"
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
				<h1 class="page-header">Add Category Settings</h1>
		</div>
                <div class="panel-body panel-form-right">
                <div class="list-group">
                        <label>
                            Select Category</label>
                        <asp:Label ID="lblcatid" runat="server" Visible="false"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlcategory" class="form-control" AutoPostBack="true">
                        </asp:DropDownList>
                        <%-- <p class="help-block">Select Your Category</p>--%>
                   <br />
                        <label>
                            Select Branch(MultiSelect)
                        </label>
                        <asp:TextBox ID="txtbranch" runat="server" onkeyup="SearchEmployees(this,'#chkbranch');"
                            CssClass="form-control"></asp:TextBox>
                            <br />
                        <asp:CheckBoxList ID="chkbranch" runat="server">
                        </asp:CheckBoxList>
                      <%--  <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please select at least one item."
                            ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />--%>
                    <br />
                    <asp:Button ID="btnSubmit"  runat="server" width="150px"
                        class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnclaear"  runat="server" width="150px"
                        class="btn btn-lg btn-link" Text="Clear" OnClick="btncancel_Click" />
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
