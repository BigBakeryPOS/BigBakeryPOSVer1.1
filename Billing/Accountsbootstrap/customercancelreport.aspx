<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customercancelreport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.customercancelreport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Sales Report</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
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
            alert('Are You Sure, You want to delete This Customer!');
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
             <div class="container-fluid">
	        <div class="row">
            <div class="col-lg-12">
            <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Customer Cancel Sales Report</h1>
	    </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <label>
                                        Filter By Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        Payment Mode</label>
                                    <asp:DropDownList ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                                        AutoPostBack="true" CssClass="form-control">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        From Date</label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                        OnTextChanged="txtfromdate_TextChanged">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        To Date</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txttodate">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                </div>
                                <div class="row">
                                <div class="col-lg-3">
                                <br />
                                    <asp:Button ID="btnall" runat="server" Text="Generate Report" 
                                       CssClass="btn btn-info pos-btn1" OnClick="btnall_Click" />
                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" Text="Export to Excel" Visible="true" runat="server" CssClass="btn btn-success"
                                           OnClick="btnExport_Click" />
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button ID="btnViewAll" runat="server" Text="View All" Visible="false" CssClass="btn btn-success"
                                        OnClick="btnViewAll_Click" />
                                </div>
                                <div class="col-lg-12">
                                    
                                        <br />
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"></asp:Label>
                                        
                                    
                                    <div class="table-responsive panel-grid-left" id="div1" runat="server">
                                      <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"></asp:Label>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="150" cssClass="table table-striped pos-table"
                                                        DataKeyNames="BillNo,typeid,Branch" ShowFooter="true" OnPageIndexChanging="Page_Change" OnRowDataBound="gvCustsales_RowDataBound"
                                                        AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True" padding="0" spacing="0" border="0">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="true" />
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="BillNo."
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
                                                                                <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString='{0:f3}' />
                                                                                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                                            <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                                            <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MMM/yyyy hh:mm:ss tt}' />
                                                            <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Cancelled By" DataField="Reference" />
                                                            <%--   <asp:BoundField HeaderText="Cancel Date" DataField="Canceltine"  />--%>
                                                        </Columns>
                                                       <%-- <HeaderStyle BackColor="#990000" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                    </asp:GridView>
                                               
                                                    Total Net amount:<label id="lblTotal" runat="server"></label>
                                                <br />
                                                    Total Disc amount:<label id="disc" runat="server"></label>
                                              <br />
                                                    Total amount:<label id="gndtotal" runat="server"></label>
                                               
                                    </div>
                                    <div style="color:#007aff"  class="form-group">
                                        <label id="lblNoRecords" style="color: Red" runat="server">
                                        </label>
                                        <br />
                                        <i>You are viewing page
                                            <%=gvCustsales.PageIndex + 1%>
                                            of
                                            <%=gvCustsales.PageCount%>
                                        </i>
                                    </div>
                                    
                                </div>
                            </div>
                           </div>
                        </div>
                       
           </div>
           </div>
           </div>
           </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvCustsales" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Updatepnel">
        <%--<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
<img alt="" src="../images/Preloader_10.gif" />
</div>
</div>
</ProgressTemplate>--%>
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
