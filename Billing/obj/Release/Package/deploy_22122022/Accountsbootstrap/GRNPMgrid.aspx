<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRNPMgrid.aspx.cs" Inherits="Billing.Accountsbootstrap.GRNPMgrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>GRN (+)(-)</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>

    <link href="../Styles/chosen.css" rel="Stylesheet" />
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
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
    
</head>
<body style="" >
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                     <form id="Form1" runat="server">
                     <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
             <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Search By Item
            <span class="pull-right">
          <asp:LinkButton ID="addbtn" runat="server" onclick="btnadd_Click">
             <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                                             </asp:LinkButton>
                  
                </span></h1>
	    </div>
                                 <div class="panel-body">
                                <div class="row">
                                <div class="col-lg-3">
                                <label>Search By Item</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlfilter"  runat="server">
                                           <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Item Name" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                <br />
                                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label>
                                </div>


                                   <div class="col-lg-3">
                                    <br />
                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search"   OnClick="Search_Click"  /> 

                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-secondary" Text="Reset"  OnClick="Reset_Click"  /> 
                                   
                                    </div>
                                        <asp:Button ID="btnTransfer" runat="server" class="btn btn-success" 
                                        Text="Transfer" style="margin-top: 10px;display:none" onclick="btnTransfer_Click"  />
										</div>
                                        <div class="col-lg-12">
                                <div class="row">        
                             <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gridview" runat="server" AllowPaging="true" PageSize="30"   
                                        OnPageIndexChanging="Page_Change"  AutoGenerateColumns="false"  
                                        cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" onrowcommand="gvstock_RowCommand">
                                <%--<HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1"  Mode="Numeric"  />--%>
                                <PagerStyle CssClass="pos-paging" />
                                <Columns>
                                
                                    <asp:BoundField HeaderText="Group " DataField="category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                                    <asp:BoundField HeaderText="Quantity" DataField="Grn_Qty"/>
                                </Columns>
  
 <%--<FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                </div>
                                </div>
                                </div>
                                </div>
                                </div>
                                </div>
									</div>
                                    	
									
                 <asp:panel class="popupConfirmation" id="DivDeleteConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Stock List</div>
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
</asp:panel>                 
                               
                                </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		

</body>
</html>

