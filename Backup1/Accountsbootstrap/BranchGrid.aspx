<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.BranchGrid" %>

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
    <title>Branch Grid Master</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
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
            alert('Are You Sure, You want to delete This Branch!');
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
       <div class="row panel-custom1">
              <div class="panel-header">
                  <h1 class="page-header">Branch Master
                  <span class="pull-right">
                  <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Onclick">
                  
                                                <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                   </asp:LinkButton>
                   </span>
                   </h1>
	            </div>
              <div class="panel-body">
                    <div class="row">
                                <div class="col-lg-4">
                                    
                                </div>
                               
                                <div class="col-lg-8">
                                    <asp:Label runat="server" ID="lbMessage" Visible="false" Text="* Given Branch's Creation Limit Exceed. Please Contact Bigdbiz Solutions Pvt.Ltd. Thank You!'" ForeColor="Red" Font-Size="17px" Font-Bold="true"></asp:Label>
                                </div>
                                
                                 <%--<table class="table table-striped pos-table">
                                <tr id="Tr1" runat="server" visible="false">
                                    <td>
                                        <div>
                                            <asp:Label runat="server" ID="lblSelectedValue"></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlfilter" Style="width: 170px; margin-left: 110px;"
                                                Visible="true" runat="server">
                                                <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="User Name" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Email" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                                onkeyup="Search_Gridview(this, 'gvcust')" placeholder="Search Text" Style="width: 170px;
                                                margin-top: -35px; margin-left: 290px;"></asp:TextBox>
                                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" OnClick="Search_Click"
                                                Style="width: 120px; margin-top: -56px; margin-left: 475px;" Visible="true" />
                                            <asp:Button ID="btnrefresh" runat="server" class="btn btn-primary" Text="Reset" PostBackUrl="~/Accountsbootstrap/userGrid.aspx"
                                                Style="width: 120px; margin-top: -56px; margin-left: 10px;" />
                                        </div>
                                    </td>
                                </tr>
                                </table>--%>
                                  <div class="col-lg-12">
                                <div class="table-responsive panel-grid-left">
                                    <asp:GridView ID="gvcust" EmptyDataText="No records Found" runat="server" CssClass="table table-striped pos-table"
                                            AutoGenerateColumns="false" OnRowCommand="gvcust_RowCommand" Width="100%" padding="0" spacing="0" border="0">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="login_id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbllogin_id" runat="server" CommandArgument='<%#Eval("BranchId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Branch Name" DataField="BranchName"  />
                                                <asp:BoundField HeaderText="Contact Name" DataField="ContactName"  />
                                                <asp:BoundField HeaderText="Mobile No." DataField="MobileNo"  />
                                                <asp:BoundField HeaderText="LandLine No." DataField="LandLine"  />
                                                <asp:BoundField HeaderText="B.Email" DataField="Email"  />
                                                <asp:BoundField HeaderText="P.Email" DataField="Pemail" Visible="false"  />
                                                <asp:BoundField HeaderText="I.Email" DataField="Iemail" Visible="false"  />
                                                <asp:BoundField HeaderText="O.Email" DataField="Oemail" Visible="false"  />
                                                <asp:TemplateField  HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" runat="server" cssclass="btn btn-warning btn-md" CommandArgument='<%#Eval("BranchId") %>'
                                                            CommandName="edit">
                                                            <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png" Width="55px" Visible="false" />
                                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Delete" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("BranchId") %>'
                                                            CommandName="delete" OnClientClick="alertMessage()">
                                                            <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/DeleteIcon_btn.png" /></asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("BranchId") %>' />
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
    </div>
    </div>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>

    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Brand List</div>
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
