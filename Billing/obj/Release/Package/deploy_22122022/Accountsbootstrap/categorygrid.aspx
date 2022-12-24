<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categorygrid.aspx.cs" Inherits="Billing.Accountsbootstrap.categorygrid" %>

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
    <title>Category Details </title>
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
    <link href="../css/Pos_style.css" rel="stylesheet">
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
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-8">
            <div class="row panel-custom1">
               <div class="panel-header">
          <h1 class="page-header">Master Category</h1>
	    </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                        <div class="form-group has-feedback">
                            <asp:TextBox CssClass="form-control" ID="txtsearch" placeholder="Search Category.."
                                onkeyup="Search_Gridview(this, 'gridview')" runat="server" MaxLength="50">
                                </asp:TextBox>
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                          </div>
                        </div>
                        <div class="col-lg-3">
                            <asp:Button ID="btnresret" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Btn_Reset"
                                Width="150px" />
                            <%-- <asp:DropDownList ID="drptype" runat="server" Visible="false" CssClass="form-control" >
                                        <asp:ListItem Text="Fetching Old/New Category" Value="1" Selected="True" ></asp:ListItem>
                                        <asp:ListItem Text="Fetching New Category" Value="2" ></asp:ListItem>
                                        </asp:DropDownList>--%>
                        </div>

                        <div class="col-lg-3">
                            <asp:Button ID="btnaddmargin" runat="server" class="btn btn-info pos-btn1" Text="Fetching Margin"
                                OnClick="Margin_Click" Width="150px" />
                            <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Sync.category"
                                OnClick="btnsyncclick_OnClick" Visible="false" Width="150px" />
                                
                       </div>
                    
                    <div class="col-lg-12">
                         <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gridview" runat="server" AllowPaging="false" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                 AllowSorting="true" OnRowCommand="gvcat_RowCommand"
                                OnSorting="gridview_Sorting" OnRowDataBound="gridview_OnRowDataBound" OnRowEditing="gridview_RowEditing" padding="0" spacing="0" border="0">
                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                <Columns>
                                    <asp:BoundField HeaderText="Category Name" DataField="category" />
                                    <asp:BoundField HeaderText="Print Category Name" DataField="Printcategory" />
                                    <asp:BoundField HeaderText="Type" DataField="Type" />

                                     <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                            <asp:Image ID="Image2" runat="server" Width="70" Height="60" ImageUrl='<%#Eval("ImagePath")%>' />
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandArgument='<%#Eval("CategoryID") %>'
                                                CommandName="Edit" cssclass="btn btn-warning btn-md" runat="server">
                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" visible="false"/>
                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("CategoryID") %>' CommandName="Del" cssclass="btn btn-danger btn-md"
                                                runat="server">
                                                <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" visible="false"/>
                                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
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
				<h1 class="page-header">Add Category/ Group</h1>
		        </div>
                <center><blink> <label  style="color:#007aff">Need To Add Category Name and Code</label></blink></center>
                    <div class="panel-body panel-form-right">
                          <div class="list-group">
                                <asp:TextBox CssClass="form-control" ID="txtcategoryId" runat="server" Visible="false"></asp:TextBox>
                            
                                <label>Category/Group Name</label>
                                <asp:ListBox Visible="false"  runat="server" DataValueField="CategoryID"
                                    ID="listcategory" CssClass="form-control" AutoPostBack="true"></asp:ListBox>
                                <asp:TextBox CssClass="form-control" ID="txtcategory" runat="server" placeholder="To Add New Category"
                                    Style="text-transform: capitalize"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="txtcat" ControlToValidate="txtcategory"
                                    ValidationGroup="val1" ErrorMessage="Please enter your Category!" Style="color: Red" />
                            <br />
                                <label>Category/Group Code</label>
                                <asp:TextBox CssClass="form-control" ID="txtcatcode" runat="server" placeholder="Enter Category Code"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rvcatcode" ControlToValidate="txtcatcode"
                                    ValidationGroup="val1" ErrorMessage="Please enter your Category!" Style="color: Red" />
                                <label id="lblCatID" visible="false" runat="server">
                                </label>
                            <br />
                                <label>
                                    Print Category/Group Name</label>
                                <asp:TextBox CssClass="form-control" ID="txtprintcat" runat="server" placeholder="To Add New Print Category"
                                    Style="text-transform: capitalize"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtprintcat"
                                    ValidationGroup="val1" ErrorMessage="Please enter your Category!" Style="color: Red" />
                            <br />
                                <label>
                                    Production/Icing</label>
                                <asp:RadioButtonList ID="rdbtype" runat="server" RepeatColumns="3">
                                    <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                                    <asp:ListItem Text="Icing" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Store Item" Value="S"></asp:ListItem>
                                </asp:RadioButtonList>
                            <br />
                                <asp:CheckBox ID="chkrequestcateory" runat="server" Width="20px" />
                                <label>Show Request/Production</label>
                                <br />
                                 <asp:CheckBox ID="chkproductioncategory" Visible="false" runat="server" Width="20px"/>
<%--                                <label>Show Production</label>
                                <br />--%>
                                <asp:CheckBox ID="chkmanualgrn" runat="server" Width="20px" />
                                <label>Show Manual GRN</label>
                                
                            <br /><br />
                                <label>Category Type</label>
                                <asp:DropDownList ID="drpcattype" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Normal Category" Value="N" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Combo Category" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Happy Hours Category" Value="H"></asp:ListItem>
                                </asp:DropDownList>
                          
                            <br />
                                <label>
                                    Image Upload</label>
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="fp_Upload" runat="server" style="display:inline" width="55%"/>
                                        <asp:Button ID="btnUpload123" runat="server" Text="Upload" CssClass="btn btn-info pos-btn1 "
                                            OnClick="btnUpload_Clickimg"  />
                                            <asp:Image ID="img_Photo" runat="server"
                                                Width="5pc" BorderColor="1" />
                                        <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUpload123" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <br />
                             

                            </div>


                            <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="false" AllowSorting="true" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" >
                                <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                <Columns>

                                   <asp:TemplateField HeaderText="Branch" ItemStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" Text='<%#Eval("BranchName") %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hidBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Margin" ItemStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtmargin" Text='<%#Eval("Margin") %>' runat="server" >0</asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtmargin" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnSave_Click"
                                ValidationGroup="val1" AccessKey="s" Width="150px" />
                            <label>
                            </label>
                            <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="Exit_Click"
                                Width="110px" />

                            
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
                    Category List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                    <blink> <label  style="color:Red; font-size:12px">If you Delete This Category It Will Affect Your Branchs!!!</label> </blink>
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
