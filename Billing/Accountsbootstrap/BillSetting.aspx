<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillSetting.aspx.cs" Inherits="Billing.Accountsbootstrap.BillSetting" %>

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
    <title>Bill Paymode Setting</title>
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
        var GridId = "<%=gvsales.ClientID %>";
        var ScrollHeight = 300;
        window.onload = function () {
            var grid = document.getElementById(GridId);
            var gridWidth = grid.offsetWidth;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            table.style.cssText = grid.style.cssText;
            table.style.width = gridWidth + "px";
            table.appendChild(document.createElement("tbody"));
            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];
            for (var i = 0; i < cells.length; i++) {
                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }
                cells[i].style.width = parseInt(width - 3) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
            }
            parentDiv.removeChild(grid);

            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
    </script>
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
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

        function alertorder() {
            alert('Are You Sure, You want to cancel This Customer sales!');
        }
    </script>

    <style>
        .chkChoice input
        {
            margin-left: -30px;
        }
        .chkChoice td
        {
            padding-left: 45px;
        }
        
        .chkChoice1 input
        {
            margin-left: -20px;
        }
        .chkChoice1 td
        {
            padding-left: 40px;
        }
    </style>

</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">  </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="row panel-custom1">
                    <div class="panel-header">
                        <h1 class="page-header">Bill Setting Details - Sales List</h1>
                    </div>

                    <div class="panel-body">

                        <form runat="server" id="form1" method="post">

                            <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>

                                    <asp:Label ID="lblmulticheck" runat="server" Visible="false" Text="20"></asp:Label>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="col-lg-3">
                                                <label>
                                                    Select Date</label>
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control center-block"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                            <div class="col-lg-3">
                                                <br />
                                                <asp:Button ID="btnsearch" runat="server" class="btn btn-secondary" Text="Refresh"
                                                    OnClick="Search_Click" />
                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnbillprocess" runat="server" class="btn btn-success pos-btn1" Text="Process Bill's"
                                                    OnClick="process_Click" />
                                            </div>
                                            <div id="Div2" runat="server" visible="false">
                                                <label>
                                                    Select All</label>
                                                <asp:RadioButtonList ID="allradselect" RepeatColumns="2" RepeatDirection="Horizontal"
                                                    runat="server" OnSelectedIndexChanged="radselect_All" AutoPostBack="true">
                                                    <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Card" Value="4"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="col-lg-6">

                                                <label>
                                                    Enter Billno</label>
                                                <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" Width="200px" OnTextChanged="Bill_chnage" AutoPostBack="true"
                                                    placeholder="Enter Billno and Press Tab" onkeyup="Search_Gridview(this, 'gvsales')"></asp:TextBox>

                                                <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gvsales" align="center" runat="server" DataKeyNames="salesid,salestype" AllowPaging="false" PageSize="25" CssClass="table table-striped pos-table"
                                                        AutoGenerateColumns="false" OnRowCommand="gvsales_RowCommand" OnRowDataBound="gvsales_RowDataBound" padding="0" spacing="0" border="0" EmptyDataText="No Records Found">
                                                        <%-- <HeaderStyle BackColor="#990000" />
                                                        <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                        <PagerStyle CssClass="pos-paging" />
                                                        <Columns>
                                                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                            <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                                            <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}' />
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblsalesid" runat="server" Text='<%#Eval("SalesID")  %>' Style="display: none"></asp:Label>
                                                                    <asp:Label ID="lblipaymode" runat="server" Text='<%#Eval("ipaymode")  %>' Style="display: none"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="SalesID" DataField="SalesID" Visible="false" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="NetAmount" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Payment Type" DataField="Payment_Mode" DataFormatString="{0:f}" />
                                                            <asp:TemplateField HeaderText="Sales Type">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="lblradtype" CssClass="chkChoice1" RepeatColumns="3" Width="100px"
                                                                        runat="server">
                                                                        <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Card" Value="4"></asp:ListItem>
                                                                        <asp:ListItem Text="Paytm" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="Bharatpe" Value="17"></asp:ListItem>
                                                                        <%--<asp:ListItem Text="Multipayment" Value="20"></asp:ListItem>--%>
                                                                    </asp:RadioButtonList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Multi Payment">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") +","+Eval("BillNo") +", "+ Eval("NetAmount").ToString() %>'
                                                                        CommandName="Mpayment" Visible="true">
                                                                        <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/posmulti.png" Width="37px" />
                                                                    </asp:LinkButton>
                                                                    <%--  <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                        CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                                        PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                                    </ajaxToolkit:ModalPopupExtender>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                        TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                                    </ajaxToolkit:ConfirmButtonExtender>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <%-- <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <br />
                                                <br />
                                                <label>Cash Bill's</label>
                                                <br />
                                                <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gridcash" align="center" runat="server" AllowPaging="false" PageSize="25"
                                                        AutoGenerateColumns="false" CssClass="table table-striped pos-table" EmptyDataText="No Records Found" padding="0" spacing="0" border="0">
                                                        <%--<HeaderStyle BackColor="#990000" />
                                                       <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                        <PagerStyle CssClass="pos-paging" />
                                                        <Columns>
                                                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                            <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                                            <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}' />
                                                            <asp:BoundField HeaderText="SalesID" DataField="SalesID" Visible="false" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="NetAmount" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Payment Type" DataField="Payment_Mode" DataFormatString="{0:f}" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <br />
                                                <br />
                                                <label>Card Bill's</label><br />
                                                <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gridcard" align="center" runat="server" AllowPaging="false" PageSize="25" CssClass="table table-striped pos-table"
                                                        AutoGenerateColumns="false" EmptyDataText="No Records Found" padding="0" spacing="0" border="0">
                                                        <%-- <HeaderStyle BackColor="#990000" />
                                                        <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                        <Columns>
                                                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                            <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                                            <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}' />
                                                            <asp:BoundField HeaderText="SalesID" DataField="SalesID" Visible="false" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="NetAmount" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Payment Type" DataField="Payment_Mode" DataFormatString="{0:f}" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:LinkButton Text="" ID="lnkFake" runat="server"></asp:LinkButton>
                            <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup"
                                TargetControlID="lnkFake" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel Width="30%" class="popupConfirmation" ID="pnlPopup" Style="display: none; background: #fffbd6"
                                runat="server">
                                <div class="popup_Container">
                                    <div class="popup_Titlebar" id="PopupHeader">
                                        <div align="center" style="color: Red" class="TitlebarLeft">
                                            Payment Details 
                                        </div>
                                        <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                        </div>
                                    </div>
                                    <div align="center" style="color: Red" class="popup_Body">
                                        <br />
                                        <label>Last Payment Details</label>
                                        <br />
                                        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField HeaderText="Payment Name" DataField="mode" />
                                                <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                            </Columns>
                                        </asp:GridView>
                                        <br />

                                        <b>
                                            <asp:Label ID="lblsalesid" runat="server" Text="0" Visible="false"></asp:Label>
                                          Billno -  <asp:Label ID="lbllbillno" runat="server"></asp:Label>
                                            :Total -
                                        <asp:Label ID="lblamount" runat="server"></asp:Label>
                                        </b>
                                        <asp:GridView ID="gvpayment" runat="server" OnRowDeleting="gridorder_RowDeleting" AutoGenerateColumns="false"
                                            OnRowDataBound="gridorder_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Payment">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="drppayment" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtamount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click">
                                                            <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" Visible="false" />
                                                            <button type="button" class="btn btn-primary pos-btn1">
                                                                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                                                            </button>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div align="center" class="popup_Buttons">
                                        <asp:Button ID="btnyes" OnClick="Yes_click" runat="server" Text="Yes" CssClass="button" />
                                        <asp:Button ID="btnClose" runat="server" Text="No" CssClass="button" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </form>

                    </div>

                </div>
            </div>
        </div>
    </div>
</body>
</html>
