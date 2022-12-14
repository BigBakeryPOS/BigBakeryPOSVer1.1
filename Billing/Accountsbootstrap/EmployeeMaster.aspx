<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs"
    Inherits="Billing.Accountsbootstrap.EmployeeMaster" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <%--<style type="text/css">
        a img
        {
            border: none;
        }
        ol li
        {
            list-style: decimal outside;
        }
        div#container
        {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }
        div.side-by-side
        {
            width: 100%;
            margin-bottom: 1em;
        }
        div.side-by-side > div
        {
            float: left;
            width: 50%;
        }
        div.side-by-side > div > em
        {
            margin-bottom: 10px;
            display: block;
        }
        .clearfix:after
        {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
    </style>--%>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Employee Master</title>
    <!-- Bootstrap Core CSS -->
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
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
</head>
<body>
    <asp:Label runat="server" Visible="false" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <form runat="server" id="form1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
       <div class="panel-header">
          <h1 class="page-header">Employee Master
          <span class="pull-right">
          
                  <asp:LinkButton ID="button" runat="server" OnClick="Add_Click"
                                    >
                                                <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                                             </asp:LinkButton>
                  
                </span>
           </h1>
	    </div>
        
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label runat="server" Text="Seleted Value" ID="lblSelectedValue"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlfilter" runat="server">
                        <asp:ListItem Text="Name" Value="1"></asp:ListItem>
                        <asp:ListItem Text="MobileNo" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Email" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div><br />
                <div class="col-lg-3">
                    <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                       ></asp:TextBox>
                    <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                </div>
                <div class="col-lg-5">
                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success pos-btn1" Text="Search"  OnClick="Search_Click" />
                 
                      &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" Text="Reset"  OnClick="refresh_Click"/>
                      
                       &nbsp;&nbsp;&nbsp; <asp:Button ID="btnExport" runat="server" class="btn btn-warning pos-btn1" Text="Export to Excel"      OnClick="btnExcel_Click"  />
                </div>
            
            
            <div class="col-lg-12">
                <div class="table-responsive panel-grid-left">
                                
                                    <asp:GridView ID="gvcust" runat="server"  cssClass="table table-striped pos-table"
                                        OnRowCommand="gvcust_RowCommand" Width="100%" OnRowDataBound="gvcust_OnRowDataBound" AutoGenerateColumns="false" padding="0" spacing="0" border="0">
                                        <%--<HeaderStyle BackColor="#990000" />--%>
                                        <%--  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />--%>
                                        <%--  <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                        <Columns>
                                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                            <asp:BoundField HeaderText="Id" DataField="ledgerid" />
                                            <asp:BoundField HeaderText="Contact Name" DataField="CustomerName" />
                                            <asp:BoundField HeaderText="Contact Type" DataField="ContactType" />
                                            <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                            <asp:BoundField HeaderText="Area" DataField="Area" />
                                            <asp:BoundField HeaderText="Email" DataField="Email" />
                                              <asp:BoundField HeaderText="IsActive" DataField="IsActive" />
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnedit" runat="server" cssclass="btn btn-warning btn-md" CommandArgument='<%#Eval("ledgerid") %>'
                                                        CommandName="editt">
                                                        <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png" width="55px" Visible="false"/>
                                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                        </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("ledgerid") %>'
                                                        CommandName="deleteee" OnClientClick="alertMessage()">
                                                        <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" /></asp:LinkButton>
                                                    <asp:ImageButton ID="imgdisable1321" ImageUrl="~/images/delete.png" runat="server"
                                                        Visible="false" Enabled="false" ToolTip="Not Allow To Delete" />
                                                    <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                        CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                        PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                    </ajaxToolkit:ModalPopupExtender>
                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                        TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                         </div>   </div>    
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
                    Customer List</div>
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
