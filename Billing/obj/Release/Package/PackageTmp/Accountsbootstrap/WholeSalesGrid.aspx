<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WholeSalesGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.WholeSalesGrid" %>

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
    <title>Whole Sales Details </title>
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
    <div class="row">
        <!-- /.col-lg-12 -->
    </div>
    <div class="row" align="center">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #0071BD; color: White">
                    Whole Sales Details
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div>
                            <form runat="server" id="form1" method="post">
                            <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                    <div class="form-group">
                                        <div class="col-lg-12" runat="server" visible="false">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Cusromer Name</label><br />
                                                    <asp:DropDownList runat="server" ID="ddlcustomer" CssClass="chzn-select" Width="150px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" onkeyup="Search_Gridview(this, 'gvCustsales')"
                                                    Style="margin-top: 10px;" />
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
                                        <div class="col-lg-12">
                                            <div class="col-lg-2">
                                            </div>
                                            <div class="col-lg-1">
                                                <label>
                                                    From Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtFDate" runat="server" MaxLength="50"
                                                    Style="width: 110px;"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtFDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>
                                                    To Date</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTDate" runat="server" MaxLength="50"
                                                    Style="width: 110px;"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtTDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>
                                                    Select Customer</label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlCus" Style="width: 250px;" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-1">
                                                <br />
                                                <div class="form-group">
                                                    <asp:Button ID="btnSearchNew" runat="server" class="btn btn-success" Text="Search"
                                                        Width="110px" OnClick="btnSearchNew_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <br />
                                                <div class="form-group">
                                                    <asp:Button ID="btnresret" runat="server" Width="110px" class="btn btn-warning" Text="Reset"
                                                        OnClick="btnReset_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <br />
                                                <div class="form-group">
                                                    <asp:Button ID="btnadd" runat="server" class="btn btn-info" Text="Add" Width="110px"
                                                        PostBackUrl="~/Accountsbootstrap/WholeSales.aspx" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div class="col-lg-12">
                                            <asp:GridView ID="gvsales" align="center" EmptyDataText="No Records Found" runat="server"
                                                ShowFooter="true" AllowPaging="false" PageSize="50" AutoGenerateColumns="false"
                                                CssClass="mGrid" OnRowDataBound="gridview_OnRowDataBound" OnRowCommand="gvsales_RowCommand">
                                                <HeaderStyle BackColor="#990000" />
                                                <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNo">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Bill No" DataField="FullBillNo" />
                                                    <asp:BoundField HeaderText="BillDate" DataField="BillDate" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}" />
                                                    <asp:BoundField HeaderText="DCNo" DataField="DCNo" />
                                                    <asp:BoundField HeaderText="ONo" DataField="OrderNo" />
                                                    <asp:BoundField HeaderText="CustomerName" DataField="CustomerName1" />
                                                    <asp:BoundField HeaderText="PayMode" DataField="PayMode1" />
                                                    <asp:BoundField HeaderText="GrandTotal" DataField="GrandTotal" DataFormatString="{0:f}"
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Receipt" DataField="Receipt" DataFormatString="{0:f}"
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="ReturnAmount" DataField="ReturnAmount" DataFormatString="{0:f}"
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="CloseDiscount" DataField="CloseDiscount" DataFormatString="{0:f}"
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="CR Note" DataField="CreditNoteAmount" DataFormatString="{0:f}"
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString="{0:f}" Visible="false" />
                                                    <asp:BoundField HeaderText="Discount" DataField="DiscAmount" DataFormatString="{0:f}"
                                                        Visible="false" />
                                                    <asp:TemplateField HeaderText="Cancel Sales" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="cancel">
                                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png" /></asp:LinkButton>
                                                            <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                                PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                            </ajaxToolkit:ModalPopupExtender>
                                                            <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View Details" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="view">
                                                                <asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" width="55px"/></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="Editt" runat="server">
                                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="CRNote" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnCRNote" ForeColor="White" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="CRNote" runat="server">
                                                                <asp:Image ID="imdCRNote" ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Inv.Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="print">
                                                                <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px"/></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DC Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndcprint" runat="server" CommandArgument='<%#Eval("SalesID") %>'
                                                                CommandName="dcprint">
                                                                <asp:Image ID="dcprint" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                            </asp:GridView>
                                            <asp:GridView ID="gvCustsales" runat="server" CssClass="mGrid" DataKeyNames="BillNo"
                                                ShowFooter="true" EmptyDataText="No Records Found" AutoGenerateColumns="false"
                                                ShowHeaderWhenEmpty="True">
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
                                                                <asp:GridView runat="server" ID="gvLiaLedger" CssClass="mGrid" GridLines="Both" AutoGenerateColumns="false"
                                                                    DataKeyNames="SalesID" ShowFooter="true">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Transid" Visible="false" DataField="SalesID" />
                                                                        <asp:BoundField HeaderText="Product" DataField="Definition" />
                                                                        <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                                                        <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" DataFormatString='{0:f}' />
                                                                        <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                                        <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}'
                                                                            Visible="false" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" Visible="false" />
                                                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' Visible="false" />
                                                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                    <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}'
                                                        Visible="false" />
                                                    <asp:BoundField HeaderText="Status" DataField="labl" />
                                                    <asp:BoundField HeaderText="Cancel status" DataField="cancelstatus" />
                                                    <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                    <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />
                                                    <asp:BoundField HeaderText="Tax-Amount" DataField="Tax" DataFormatString='{0:f}' />
                                                    <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                                                </Columns>
                                                <HeaderStyle BackColor="#990000" />
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                    NextPageText="Next" PreviousPageText="Previous" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            </asp:GridView>
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
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</body>
</html>
