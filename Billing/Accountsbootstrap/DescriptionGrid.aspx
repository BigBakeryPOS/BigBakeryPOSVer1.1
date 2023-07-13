<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescriptionGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DescriptionGrid" %>

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
    <title>Item Master </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (dropdownchk(document.getElementById('ddlcategory'), "Select Category")
            //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
        && blankchk(document.getElementById('txtdescription'), "Description")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
        

    </script>
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
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
        <div class="col-lg-12">
            <div class="row panel-custom1">
                <div class="panel-header">
                  <h1 class="page-header">Item Master
                  <span class="pull-right">
          <asp:LinkButton ID="btnadd" runat="server" onclick="btnadd_Click" >
                                                <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                                             </asp:LinkButton>
                  
                </span>
                  </h1>
	            </div>
                <div class="panel-body">
                    <div class="row">
                                    <div runat="server" visible="false">
                                        <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control" Style="width: 150px">
                                            <asp:ListItem Text="Select by" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Category" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Item" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="S.No" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>


                                    <div class="col-lg-3">
                                    <div class="form-group has-feedback">
                                        <asp:TextBox CssClass="form-control" placeholder="Search Item.." ID="txtdescription"
                                            onkeyup="Search_Gridview(this, 'gridview')" runat="server" MaxLength="50"></asp:TextBox>
                                        <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                    </div>
                                    </div>

                                    <%--<div runat="server" visible="false">
                                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Search" OnClick="Button1_Click"
                                            Width="150px" /></div>--%>
                                    <div class="col-lg-2">
                                        <asp:Button ID="Button2" runat="server" class="btn btn-secondary" Text="Reset" OnClick="Button2_Click"
                                            Width="150px" />
                                            </div>
                                    
                                    <div class="col-lg-3">
                                        <asp:Button ID="btnmakeallbranch" runat="server" class="btn btn-success pos-btn1" Text="Make Item All Branch Visible"
                                            OnClick="btnmakeallbranch_Click"/>
                                    </div>
                                </div>
                                <br />
                                <br />
                     <div class="row">
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Button ID="btndownload" runat="server" Text="Download" OnClick="btndownload_Click" />
                                            </div>
                                        </div>
                         </div>
                   
                                <div class="row">
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            
                                            <label>
                                                Upload Data From Excel
                                            </label><br /><br />
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" style="display:inline" width="65%"/>
                                                    <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                        OnClick="Async_Upload_File" />
                                                    <asp:Button ID="btnUpload" CssClass="btn btn-danger pos-btn1" runat="server" Text="Upload"
                                                        OnClick="Upload_File" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:GridView ID="GridView2" runat="server">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="col-lg-4" runat="server" visible="true">
                                        <div class="form-group">
                                            <label>
                                                Upload Data From Excel (HSNCODE/TAX/RATE)
                                            </label>
                                            <asp:RadioButtonList ID="btntype" runat="server" RepeatColumns="3">
                                                <asp:ListItem  Text="HSNCODE" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="TAX" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="RATE" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:FileUpload ID="FileUpload2" runat="server" style="display:inline" width="50%" />
                                                    <asp:Button ID="btnAsyncUploadUpdate" Visible="false" runat="server" Text="Async_Upload"
                                                        OnClick="Async_Upload_File_Update" />
                                                    <asp:Button ID="btnUploadUpdate" CssClass="btn btn-danger pos-btn1" runat="server" Text="Upload"
                                                        OnClick="Upload_File_Update" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAsyncUploadUpdate" EventName="Click" />
                                                    <asp:PostBackTrigger ControlID="btnUploadUpdate" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:GridView ID="GridView1" runat="server">
                                            </asp:GridView>
                                        </div>
                                    
                                    </div>
                                    <%--<div class="col-lg-2">
                                        <asp:Button ID="btnitemsync" runat="server" class="btn btn-success" Text="Item sync From Production"
                                            Visible="false" OnClick="btnsyncclick" Width="150px" />
                                    </div>--%>
                                </div>
                            
                            
                                
                                    <div class="table-responsive panel-grid-left">
                                        
                                                        <asp:GridView ID="gridview" runat="server" AllowPaging="false" Width="100%" AutoGenerateColumns="false"
                                                            cssClass="table table-striped pos-table" EmptyDataText="No Records Found" AllowSorting="true" OnRowCommand="gvcust_RowCommand"
                                                            OnSorting="gridview_Sorting" OnRowDataBound="gridview_OnRowDataBound" padding="0" spacing="0" border="0">
                                                           <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" Height="24px"
                                                                BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" />
                                                            <%-- <HeaderStyle BackColor="#990000" ForeColor="White" />
                                                            <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Category User ID" DataField="CategoryuserID" Visible="false" />
                                                                <asp:BoundField HeaderText="Category ID" DataField="CategoryID" Visible="false" />
                                                                <asp:BoundField HeaderText="Group" DataField="category" />
                                                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                                <asp:BoundField HeaderText="Print Item Name" DataField="PrintItem" />
                                                                <asp:TemplateField HeaderText="Rate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tax %">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltaxper" runat="server" Text='<%#Eval("gst")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CGST Value">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcgstvalue" runat="server" Text='<%#Eval("SGST")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SGST Value">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsgstvalue" runat="server" Text='<%#Eval("CGST")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tax Value">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltaxvalue" runat="server" Text='<%#Eval("Ttax")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:BoundField HeaderText="Tax%" DataField="" DataFormatString='{0:f}' />
                                                                <asp:BoundField HeaderText="SGST" DataField="" DataFormatString='{0:f}' />
                                                                <asp:BoundField HeaderText="CGST" DataField="" DataFormatString='{0:f}' />
                                                                <asp:BoundField HeaderText="Tax Value" DataField="" DataFormatString='{0:f}' />--%>
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbrate1" runat="server" Text='<%#Eval("Rate1")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Image" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image2" runat="server" Width="40" Height="40" ImageUrl='<%#Eval("ImageUpload")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="60px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("CategoryuserID") %>' CommandName="Edit" cssclass="btn btn-warning btn-md"
                                                                            runat="server">
                                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" Visible="false" />
                                                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                                            </asp:LinkButton>
                                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("categoryuserid") %>' CommandName="Del"
                                                                            runat="server">
                                                                            <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" Visible="false"/>
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
                                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
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
      
        
        
        <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
            runat="server">
            <div class="popup_Container">
                <div class="popup_Titlebar" id="PopupHeader">
                    <div class="TitlebarLeft">
                        Description List</div>
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
    <!-- /.col-lg-6 (nested) -->
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
</body>
</html>
