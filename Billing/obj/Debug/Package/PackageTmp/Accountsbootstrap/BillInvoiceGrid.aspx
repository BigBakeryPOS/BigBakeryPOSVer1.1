<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillInvoiceGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.BillInvoiceGrid" %>

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
    <title>Invoice Grid </title>
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
          <h1 class="page-header">Invoice Details
           <span class="pull-right">
          <asp:LinkButton ID="Button1" runat="server" onclick="Add_Click">
            <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD NEW BILL
			</button>
         </asp:LinkButton>
                </span>
          </h1>
	    </div>
    
                <div class="panel-body">

                           
                            <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                    <div class="row">
                                        <div class="col-lg-3">
                                                <label>
                                                    Filter By</label>
                                                <asp:DropDownList ID="ddlbillno" CssClass="form-control"  runat="server">
                                                    <asp:ListItem Text="system No" Value="a.invoiceno"></asp:ListItem>
                                                    <asp:ListItem Text="Branch Name" Value="b.brancharea"></asp:ListItem>
                                                    <asp:ListItem Text="Billed By" Value="PreparedBy"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlcustomername" CssClass="form-control" Visible="false" runat="server" >
                                                </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                Enter Search Text</label>
                                            <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" 
                                                placeholder="Enter Billno and Press Tab" onkeyup="Search_Gridview(this, 'gvsales')"
                                                AutoPostBack="true" OnTextChanged="txtAutoName_TextChanged"></asp:TextBox>
                                        </div>
                                       <div class="col-lg-3">
                                            <br />
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-primary pos-btn1" Text="Search" 
                                                OnClick="Search_Click" onkeyup="Search_Gridview(this, 'gvCustsales')" />
                                        
                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" 
                                                Text="Reset" OnClick="refresh_Click" />
                                            <asp:Button ID="btnsyncclick" runat="server" class="btn btn-warning" Text="Sync. to Production"
                                                Visible="false" OnClick="btnsyncclick_OnClick" Width="170px" />
                                        </div>
                                       
                                    </div>
                                    <div class="row">
                                    <div class="col-lg-6">
                                    <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gvsales" align="center" runat="server" AllowPaging="true" PageSize="50" cssClass="table table-striped pos-table"
                                            Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnPageIndexChanging="Page_Change"
                                            padding="0" spacing="0" border="0" AutoGenerateColumns="false" OnRowCommand="gvsales_RowCommand"
                                            EmptyDataText="No Records Found" OnRowDataBound="gvsales_OnRowDataBound">
                                              <PagerStyle CssClass="pos-paging" />
                                           <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                            <Columns>
                                                <asp:BoundField HeaderText="System No" DataField="InvoiceNo" />
                                                <asp:BoundField HeaderText="Invoice No" DataField="FullInvoiceNo" />
                                                <asp:BoundField HeaderText="Invoice Date" DataField="Invoicedate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                <asp:BoundField HeaderText="Branch Name" DataField="BranchArea" />
                                                <asp:BoundField HeaderText="Tax Amount" DataField="tax" DataFormatString="{0:f}" />
                                                <asp:BoundField HeaderText="Total Amount" DataField="Roundoff" DataFormatString="{0:f}" />
                                                <asp:BoundField HeaderText="Billed by" DataField="PreparedBy" />
                                                <asp:TemplateField HeaderText="Cancel Sales">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("InvoiceID") %>'
                                                            CommandName="cancel" Visible="true">
                                                            <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png" width="37px" Visible="false"/>
                                                            <button type="button" class="btn btn-danger btn-md">
						                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
					                                        </button>
                                                            </asp:LinkButton>
                                                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel.png"
                                                            Visible="false" />
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View Details">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("InvoiceID") %>'
                                                            CommandName="view">
                                                            <asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png"  Visible="false"/>
                                                            <button type="button" class="btn btn-primary btn-md">
						                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                            </button>
                                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Print">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("InvoiceID") %>'
                                                            CommandName="print">
                                                            <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png"  width="55px" Visible="false"/>
                                                            <button type="button" class="btn btn-default btn-md">
						                                        <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                        </button>
                                                            </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                           <%-- <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                            <%-- <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                        </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                    <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="10" DataKeyNames="invoiceid" cssClass="table table-striped pos-table"
                                            ShowFooter="true" OnPageIndexChanging="Page_Change" OnRowDataBound="gvCustsales_RowDataBound" padding="0" spacing="0" border="0"
                                            AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                             <PagerStyle CssClass="pos-paging" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%" HeaderText="System No."
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="javascript:switchViews('dv<%# Eval("invoiceid") %>', 'imdiv<%# Eval("invoiceid") %>');"
                                                            style="text-decoration: none;">
                                                            <img id="imdiv<%# Eval("Invoiceno") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                        </a>
                                                        <%# Eval("invoiceno") %>
                                                        <div id="dv<%# Eval("invoiceno") %>" style="display: none; position: relative;">
                                                            <asp:GridView runat="server" ID="gvLiaLedger" GridLines="Both" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                                 ShowFooter="true">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Product" DataField="definition" />
                                                                    <asp:BoundField HeaderText="Qty" DataField="qty" />
                                                                    <asp:BoundField HeaderText="UnitPrice" DataField="rate" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Net Amount" DataField="netamount" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="UOM" DataField="uom" />
                                                                    <asp:BoundField HeaderText="Tax Name" DataField="taxname" />
                                                                    <asp:BoundField HeaderText="GST Amount" DataField="gstamount" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Total Amount" DataField="totalamount" DataFormatString='{0:f}' />
                                                                </Columns>
                                                                <%--<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Invoice No" DataField="FullInvoiceNo" />
                                                <asp:BoundField HeaderText="Invoice Date" DataField="Invoicedate" DataFormatString='{0:d}' />
                                                <asp:BoundField HeaderText="Branch Name" DataField="BranchArea" />
                                                <asp:BoundField HeaderText="Tax Amount" DataField="tax" DataFormatString="{0:f}" />
                                                <asp:BoundField HeaderText="Total Amount" DataField="Roundoff" DataFormatString="{0:f}" />
                                                <asp:BoundField HeaderText="Billed by" DataField="PreparedBy" />
                                            </Columns>
                                            <%-- <HeaderStyle BackColor="#990000" />--%>
                                            <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <%-- <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>

                                    <td id="refre" runat="server" visible="false">
                                    </td>
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
                                        <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                        </div>
                                    </div>
                                    <div align="center" style="color: Red" class="popup_Body">
                                        <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Reference BillNo"></asp:TextBox>
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
