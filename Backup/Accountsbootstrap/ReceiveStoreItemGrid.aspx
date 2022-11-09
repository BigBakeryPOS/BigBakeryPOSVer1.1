<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveStoreItemGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ReceiveStoreItemGrid" %>

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
    <title>Receive Raw Materials </title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function alertMessage() {

            alert('This Bill Not Allow To Cancel.Please Contact Administrator!!!');
        }

        function alertMessagee() {

            alert('This Bill Not Allow To Cancel.Please Select Valid Reason Or Contact Administrator!!!');
        }

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
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
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <script type="text/javascript">

        function alertorder() {
            alert('Are You Sure, You want to cancel This Customer sales!');
        }
    </script>
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">  </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
       <form runat="server" id="form1" method="post">
<div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Receive Raw Materials
           <span class="pull-right">
          <asp:LinkButton ID="Button1" runat="server" PostBackUrl="~/Accountsbootstrap/ReceiveStoreItem.aspx">
             <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
         </asp:LinkButton>
                </span></h1>
	    </div>

                <div class="panel-body">

                            <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                  <div class="row">
                                        <div id="Div1" class="col-lg-12" runat="server" visible="false">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Cusromer Name</label><br />
                                                    <asp:DropDownList runat="server" ID="ddlcustomer" CssClass="chzn-select" Width="150px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Style="margin-top: 10px;" />
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>
                                                        Enter Billno</label>
                                                    <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" Width="200px"
                                                        placeholder="Enter Billno and Press Tab" onkeyup="Search_Gridview(this, 'gvsales')"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        
                                          <div class="col-lg-3">
                                          <div class="form-group has-feedback">
                                                <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" Placeholder="Search Deatils.."
                                                    onkeyup="Search_Gridview(this, 'gvsales')"></asp:TextBox>
                                                    <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                            </div>
                                            </div>
                                   </div>
                                   <div class="row"> 
                                        
                                            <div class="col-lg-6">
                                            <div class="table-responsive panel-grid-left">
                                                <asp:GridView ID="gvsales"  EmptyDataText="No Records Found" runat="server"  Caption="Receive Details"
                                                    AllowPaging="true" PageSize="50" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                    OnRowCommand="gvsales_RowCommand">
                                                    <%--<HeaderStyle BackColor="#990000" />--%>
                                                  <%--  <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                  <PagerStyle CssClass="pos-paging" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="ReceiveNo" DataField="RequestNo" />
                                                        <asp:BoundField HeaderText="ReceiveDate" DataField="RequestDate" DataFormatString="{0:d}" />
                                                        <asp:BoundField HeaderText="Prepared" DataField="Prepared" />
                                                        <asp:BoundField HeaderText="Prod.Qty" DataField="ProdQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="Raw.Qty" DataField="rawQty" DataFormatString="{0:f}" />
                                                        <asp:TemplateField HeaderText="Cancel Sales" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("RequestNo") %>'
                                                                    CommandName="cancel">
                                                                    <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png" visible="false" />
                                                                    <button type="button" class="btn btn-danger btn-md">
						                                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
					                                                </button>
                                                                    </asp:LinkButton>
                                                                <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                    CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                                    PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                                </ajaxToolkit:ModalPopupExtender>
                                                                <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                    TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View Details" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("RequestNo") %>'
                                                                    CommandName="view">
                                                                    <asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" visible="false"/>
                                                                    <button type="button" class="btn btn-primary btn-md">
						                                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                                </button>
                                                                    </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RequestNo") %>'
                                                                    CommandName="print">
                                                                    <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" visible="false"/>
                                                                    <button type="button" class="btn btn-default btn-md">
						                                                    <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                                    </button>
                                                                        </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <%--<FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                                   <%-- <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                            </div>
                                            </div>
                                        <div class="col-lg-6">
                                        <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gvCustsales" runat="server" ShowFooter="true"  Caption="Receive Items Details" PageSize="50" cssClass="table table-striped pos-table"
                                                EmptyDataText="No Records Found" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" padding="0" spacing="0" border="0">
                                                <PagerStyle CssClass="pos-paging" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="ReceiveNo" DataField="RequestNo" Visible="true" />
                                                    <asp:BoundField HeaderText="ReceiveDate" DataField="RequestDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                    <asp:BoundField HeaderText="Prepared" DataField="Prepared" Visible="true" />
                                                    <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                                    <asp:BoundField HeaderText="Definition" DataField="Definition" Visible="true" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                                                    <asp:BoundField HeaderText="Unit" DataField="Unit" />
                                                </Columns>
                                               <%-- <HeaderStyle BackColor="#990000" />--%>
                                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                    NextPageText="Next" PreviousPageText="Previous" />--%>
                                                <%--<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                            </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                  
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none;
                                background: #fffbd6" runat="server">
                                <div class="popup_Container">
                                    <div class="popup_Titlebar" id="PopupHeader">
                                        <div align="center" style="color: Red" class="TitlebarLeft">
                                            Warning Message!!!</div>
                                        <div align="center" style="color: Red" class="TitlebarLeft">
                                            Please use 1234567890 as Reference No for Demo version</div>
                                        <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                        </div>
                                    </div>
                                    <div align="center" style="color: Red" class="popup_Body">
                                        <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Reference Bill No. / Admin Password Admin Password"></asp:TextBox>
                                        <asp:DropDownList ID="dlReason" runat="server">
                                            <asp:ListItem Text="select"></asp:ListItem>
                                            <asp:ListItem Text="Change Product"></asp:ListItem>
                                            <asp:ListItem Text="Quantity Change"></asp:ListItem>
                                        </asp:DropDownList>
                                        <p>
                                            Are you sure want to Cancel this Bill?
                                        </p>
                                    </div>
                                    <div align="center" class="popup_Buttons">
                                        <input id="ButtonDeleleOkay" type="button" value="Yes" />
                                        <input id="ButtonDeleteCancel" type="button" value="No" />
                                    </div>
                                </div>
                            </asp:Panel>
                </div>

    </div>
    </div>
    </div>
</div>
</form>
</body>
</html>
