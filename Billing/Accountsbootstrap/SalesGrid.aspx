<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesGrid.aspx.cs" Inherits="Billing.SalesGrid" %>

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
    <title>Sales Grid </title>
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
          <h1 class="page-header">Sales Details
          <span class="pull-right">
          
          <asp:LinkButton ID="addbutton" runat="server" onclick="Add_Click">
                    <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD NEW BILL
			</button>
                  </asp:LinkButton>
                </span>
                </h1>
	    </div>
                <div class="panel-body">
                    <div class="row">
                        
                           
                            <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                   
                                        <div class="col-lg-3">
                                           
                                                <label>
                                                    Filter By</label>
                                                <asp:DropDownList ID="ddlbillno" CssClass="form-control" runat="server">
                                                    <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlcustomername" CssClass="form-control" Visible="false" runat="server">
                                                </asp:DropDownList>
                                            
                                        </div>
                                        <div class="col-lg-3">
                                            <br />
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search" 
                                                OnClick="Search_Click" onkeyup="Search_Gridview(this, 'gvCustsales')" Width="100px" />
                                        
                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary"  Width="100px"
                                                Text="Reset" OnClick="refresh_Click" />
                                        </div>
                                       
                                            <asp:Button ID="btnsyncclick" runat="server" class="btn btn-warning" Text="Sync. to Production"
                                                Visible="false" OnClick="btnsyncclick_OnClick" Width="170px" />
                                        <div class="col-lg-3">
                                            <label>
                                                Enter Billno</label>
                                            <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" 
                                                placeholder="Enter Billno and Press Tab" onkeyup="Search_Gridview(this, 'gvsales')"
                                                AutoPostBack="true" OnTextChanged="txtAutoName_TextChanged"></asp:TextBox>
                                        </div>
                                    
                                    <br />
                                    <div class="col-lg-6">
                                    <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gvsales" align="center" runat="server" AllowPaging="true" PageSize="50"
                                            Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnPageIndexChanging="Page_Change"
                                           cssClass="table table-striped pos-table"  padding="0" spacing="0" border="0" AutoGenerateColumns="false" OnRowCommand="gvsales_RowCommand"
                                            EmptyDataText="No Records Found" OnRowDataBound="gvsales_OnRowDataBound">
                                            <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                HorizontalAlign="Center" ForeColor="White" />--%>
                                            <%--   <HeaderStyle BackColor="#990000" />--%>
                                           <%-- <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                           <PagerStyle CssClass="pos-paging" />
                                            <Columns>
                                                <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                <asp:BoundField HeaderText="Bill No" DataField="fullbill" />
                                                <asp:BoundField HeaderText="SalesID" DataField="SalesID" Visible="false" />
                                                <asp:BoundField HeaderText="Contact Name" DataField="CustomerName" />
                                                <asp:BoundField HeaderText="Contact Type" DataField="ContactType" Visible="false" />
                                                <asp:BoundField HeaderText="Area" DataField="Area" Visible="false" />
                                                <asp:TemplateField Visible="false" HeaderText="Tax Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltax" runat="server" Text='<%#Eval("Tax")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="Net Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblnetamount" runat="server" Text='<%#Eval("NetAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalamount" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Tax Amount" DataField="" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Net Amount" DataField="" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="" DataFormatString="{0:f}" />--%>
                                                <asp:BoundField HeaderText="Billed by" DataField="Biller" />
                                                <asp:BoundField HeaderText="Attender" DataField="Attender" />
                                                <asp:TemplateField HeaderText="Edit" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("BillNo") %>'
                                                            CommandName="edit">
                                                            <asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" Visible="false" />
                                                            <button type="button" class="btn btn-warning btn-md">
						                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
					                                        </button>
                                                            </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cancel Sales">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>'
                                                            CommandName="cancel" Visible="true">
                                                            <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png"  Visible="false"
                                                                Width="37px" />
                                                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel.png"
                                                            Visible="false" />
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
                                                <asp:TemplateField HeaderText="View Details">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("SalesID") +", "+ Eval("salestype").ToString() %>'
                                                            CommandName="view">
                                                            <asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" visible="false" />
                                                             <button type="button" class="btn btn-primary btn-md">
						                                        <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                        </button>
                                                            </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Print">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("BillNo") +", "+ Eval("salestype").ToString() %>'
                                                            CommandName="print">
                                                            <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" Visible="false"
                                                                Width="55px" />
                                                                <button type="button" class="btn btn-default btn-md">
						                                            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                            </button>
                                                                </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                          <%--  <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                            <%-- <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                        </asp:GridView>
                                    </div>
                                    </div>
                                    <div class="col-lg-6">
                                    <div class="table-responsive panel-grid-left">
                                        <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="10" DataKeyNames="BillNo,salestype" cssClass="table table-striped pos-table"
                                            ShowFooter="true" OnPageIndexChanging="Page_Change" OnRowDataBound="gvCustsales_RowDataBound" padding="0" spacing="0" border="0"
                                            AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%" HeaderText="BillNo."
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="javascript:switchViews('dv<%# Eval("BillNo") %>', 'imdiv<%# Eval("BillNo") %>');"
                                                            style="text-decoration: none;">
                                                            <img id="imdiv<%# Eval("BillNo") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                        </a>
                                                        <%# Eval("BillNo") %>
                                                        <div id="dv<%# Eval("BillNo") %>" style="display: none; position: relative;">
                                                            <asp:GridView runat="server" ID="gvLiaLedger" GridLines="Both" AutoGenerateColumns="false" OnRowDataBound="gvlialedger" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                                DataKeyNames="SalesID" ShowFooter="true">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Transid" Visible="false" DataField="SalesID" />
                                                                    <asp:BoundField HeaderText="Product" DataField="printitem" />
                                                                    <%--<asp:BoundField HeaderText="Qty" DataField="" />--%>
                                                                    <asp:TemplateField HeaderText="Qty">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="UnitPrice">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField HeaderText="UnitPrice" DataField="" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Total Amount" DataField="" DataFormatString='{0:f}' />--%>
                                                                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}'
                                                                        Visible="false" />
                                                                </Columns>
                                                                <%--<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                                <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" Visible="false" />
                                                <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' Visible="false" />
                                                <asp:BoundField HeaderText="Sales Type" DataField="SalesType1" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}'
                                                    Visible="false" />
                                                <asp:BoundField HeaderText="Status" DataField="labl" />
                                                <asp:BoundField HeaderText="Cancel status" DataField="cancelstatus" />
                                                <asp:TemplateField HeaderText="Net Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNetAmount" runat="server" Text='<%#Eval("NetAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Disc.Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltax" runat="server" Text='<%#Eval("Tax")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Net-Amount" DataField="" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Discount-Amount" DataField="" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Tax-Amount" DataField="Tax" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="" DataFormatString='{0:f}' />--%>
                                            </Columns>
                                            <%-- <HeaderStyle BackColor="#990000" />--%>
                                           <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <%-- <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>
                                    </div>
                                    <td id="refre" runat="server" visible="false">
                                    </td>
                                    
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
                                        <br />
                                        <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Reference BillNo"></asp:TextBox>
                                        <br />
                                        <label>
                                            Reason</label><br />
                                        <asp:DropDownList ID="ddlmainreason" runat="server">
                                            <asp:ListItem Text="Customer"></asp:ListItem>
                                            <asp:ListItem Text="Partner"></asp:ListItem>
                                            <asp:ListItem Text="Retaurant(BF)"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <label>
                                            Sub Reason</label><br />
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
    </div>
    </form>
</body>
</html>
