<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarginSetting.aspx.cs" Inherits="Billing.Accountsbootstrap.MarginSetting" %>

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
    <title>Margin Setting </title>
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
          <h1 class="page-header">Margin Setting Master</h1>
	    </div>
                    <div class="panel-body">
                        <div class="row">
                          
                                <div class="col-lg-4">
                                <div class="form-group has-feedback">
                                    <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" onkeyup="Search_Gridview(this, 'gv')"
                                        placeholder="Search Tax.." MaxLength="50" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" -"
                                        TargetControlID="txtsearch" />
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                </div>
                                </div>
                                <div class="col-lg-8">
                                    <asp:Button ID="btnresret" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Btn_Reset"
                                        Width="150px" /></div>
                            
                            <div class="col-lg-12">
                     <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gv" runat="server" DataKeyNames="Catmarginid" OnRowCommand="edit" cssClass="table table-striped pos-table"
                                            EmptyDataText="Oops! No Activity Performed." AutoGenerateColumns="false" padding="0" spacing="0" border="0">
                                            <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                            <Columns>
                                                <asp:BoundField HeaderText="TaxID" DataField="Catmarginid" Visible="false" />
                                                <asp:BoundField HeaderText="Tax" DataField="printcategory" />
                                                <asp:BoundField HeaderText="Own Branch Margin" DataField="OwnBranch" />
                                                <asp:BoundField HeaderText="Fanchise Margin" DataField="franchise" />
                                                <asp:BoundField HeaderText="Fanchise Margin" DataField="Ownfranchise" />
                                                <asp:TemplateField HeaderText="Edit" Visible="true" >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("Catmarginid") %>' CommandName="EditRow" cssclass="btn btn-warning btn-md"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px" Visible="false"/>
                                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                        </asp:LinkButton>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("Catmarginid") %>' />
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
				<h1 class="page-header">Add Category Margin</h1>
		</div>
                                    
                                        <div class="panel-body panel-form-right">
                                            <div class="list-group">
                                                <asp:TextBox ID="txtid" Visible="false" runat="server"></asp:TextBox>
                                                <label>
                                                    Select Category</label>
                                                    <asp:DropDownList ID="drpcategory" runat="server" CssClass="form-control" ></asp:DropDownList>
                                                
                                                <br />
                                                <label>Own Branch Margin</label>
                                                <asp:TextBox placeholder="Enter Margin" ID="txtOmargin" runat="server" CssClass="form-control"
                                                   ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                                    FilterType="Custom,Numbers" ValidChars="."
                                                    TargetControlID="txtOmargin" />
                                                    <br />
                                                <label>Franchise Branch Margin</label>
                                                <asp:TextBox placeholder="Enter Margin" ID="txtFmargin" runat="server" CssClass="form-control"
                                                     ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="Custom,Numbers" ValidChars="."
                                                    TargetControlID="txtFmargin" />
                                                    <br />
                                                <label>Franchise/Own Branch Margin</label>
                                                <asp:TextBox placeholder="Enter Margin" ID="txtofmargin" runat="server" CssClass="form-control"
                                                   ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterType="Custom,Numbers" ValidChars="."
                                                    TargetControlID="txtofmargin" />
                                                <br />
                                           
                                                <asp:Button ID="btnSubmit" width="150px"  runat="server"
                                                    class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnclaear"  width="150px" runat="server"
                                                    class="btn btn-lg btn-link" Text="Cancel" OnClick="btncancel_Click" />
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
