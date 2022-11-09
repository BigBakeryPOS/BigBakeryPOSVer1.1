<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Offer.aspx.cs" Inherits="Billing.Accountsbootstrap.Offer" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Create HAPPY HOURS</title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>

    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcategory'), "Category")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
	</script>

    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head> 
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">HAPPY HOURS Grid
          <span class="pull-right">
          <asp:LinkButton ID="addbtn" runat="server" >
                <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
             </asp:LinkButton>
                  
                </span>
                </h1>
	    </div>

  
                <div class="panel-body">
                    <div class="row">
                    
                                        <asp:DropDownList runat="server" Visible="false" ID="ddlcategory" CssClass="form-control"
                                            Style="width: 170px; margin-left: 110px;">
                                            <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Product ID" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Category Name" Value="2"></asp:ListItem>
                                            <%-- <asp:ListItem Text="Brand Name" Value="3"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <div class="col-lg-3">
                                            <div class="form-group has-feedback">
                                        <asp:TextBox onkeyup="Search_Gridview(this, 'gridview')" CssClass="form-control"
                                            ID="txtdescription" runat="server" placeholder="Search Text" MaxLength="50" ></asp:TextBox>
                                            <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" -"
                                            TargetControlID="txtdescription" />
                                            </div>
                                            </div>
                                             <div class="col-lg-9">
                                            
                                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                        <asp:Button ID="Button1" Visible="false" runat="server" class="btn btn-success" Text="Search" />
                                        
                                        <asp:Button ID="Button2" runat="server" class="btn btn-seondary" Text="Reset"  />
                                        
                                        <asp:Button ID="Button3" runat="server" class="btn btn-success" Visible="false" Text="Bulk Addition" />
                                        
                                      &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnexcel" runat="server" class="btn btn-success" Text="Export-To-Excel"  />
                                    
                            </div>
                            <div class="col-lg-12">
                                   <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gridview" runat="server" AllowPaging="false" Width="100%" PageSize="10" 
                                            AutoGenerateColumns="false"  OnRowCommand="gridview_rowcommand" EmptyDataText="No Records Found" 
                                            AllowSorting="true" cssClass="table table-striped pos-table"  padding="0" spacing="0" border="0" >
                                            <PagerStyle CssClass="pos-paging" />
                                          <%--  <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <Columns>
                                                <asp:BoundField HeaderText="Category User ID" DataField="OfferId" Visible="false" />
                                                <asp:BoundField HeaderText="Offer Name" DataField="OfferName"   />
                                                <%--<asp:BoundField HeaderText="Vendor Name" DataField="CustomerName" />--%>
                                                <asp:BoundField  HeaderText="Total Rate"
                                                    DataField="TotalRate" />
                                                <asp:TemplateField Visible="true"  HeaderText="Edit" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("OfferId") %>' CommandName="Edit" cssclass="btn btn-warning btn-md"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Visible="false" />
                                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("OfferId") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" ItemStyle-HorizontalAlign="Center" HeaderText="Delete" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("OfferId") %>' CommandName="Del"
                                                            runat="server">
                                                            <asp:Image ID="Image1" ImageUrl="~/images/DeleteIcon_btn.png" runat="server"  visible="false"/>
                                                            <button type="button" class="btn btn-danger btn-md">
												            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
												            </button>
                                                            </asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
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
                                            <%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>
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
