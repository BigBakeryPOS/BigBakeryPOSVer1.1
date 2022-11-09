<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="salesreportmonthwise.aspx.cs"
    Inherits="Billing.Accountsbootstrap.salesreportmonthwise" %>

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
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Yearly Sales Type Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <legend>Filter By Branch</legend>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <legend>Select Date </legend>From date:
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    <%-- <label>
                                        To date</label>--%>
                                    <legend>Select Type: </legend>
                                    <asp:RadioButtonList ID="drptype" RepeatColumns="5" RepeatLayout="Table" OnSelectedIndexChanged="drptype_selectedindex"
                                        AutoPostBack="true" RepeatDirection="Horizontal" runat="server" CssClass="form-control">
                                        <asp:ListItem style="padding-left: 10px" Text="Weekly" Value="1" Enabled="true"></asp:ListItem>
                                        <asp:ListItem style="padding-left: 10px" Text="Monthly" Value="2"></asp:ListItem>
                                        <asp:ListItem style="padding-left: 10px" Text="Quartly" Value="3" Enabled="true"></asp:ListItem>
                                        <asp:ListItem style="padding-left: 10px" Text="Halfly" Value="4" Enabled="true"></asp:ListItem>
                                        <asp:ListItem style="padding-left: 10px" Text="Annual" Value="5" Enabled="true"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <legend></legend>
                                    <asp:Button ID="btnall" runat="server" Visible="false" Text="Generate Report" CssClass="btn btn-success"
                                        OnClick="btnall_Click" />
                                    &nbsp
                                    <asp:Button ID="btnViewAll" runat="server" Text="View All" Visible="false" CssClass="btn btn-success"
                                        OnClick="btnViewAll_Click" />
                                </div>
                                <div class="col-lg-12">
                                    <div>
                                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                                        &nbsp &nbsp &nbsp &nbsp
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"></asp:Label>
                                        <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"></asp:Label>
                                    </div>
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="gvCustsales" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                                        runat="server" AllowPaging="true" PageSize="12" AllowSorting="true" CssClass="myGridStyle"
                                                        OnPageIndexChanging="Page_Change" AutoGenerateColumns="false" OnRowCommand="gvcust_RowCommand"
                                                        OnSorting="gvcust_Sorting">
                                                        <HeaderStyle BackColor="#3366FF" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />
                                                        <Columns>
                                                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                              <asp:BoundField HeaderText="MonthName" DataField="Month" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                            <%--<asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                                            <asp:BoundField HeaderText="Area" DataField="Area" />
                                                            <asp:BoundField HeaderText="Email" DataField="Email" />--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td1" runat="server" >
                                                    Total:-<label id="lblTotal" runat="server"></label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="color: Green; font-weight: bold" class="form-group">
                                        <label id="lblNoRecords" style="color: Red" runat="server">
                                        </label>
                                        <br />
                                        <i>You are viewing page
                                            <%=gvCustsales.PageIndex + 1%>
                                            of
                                            <%=gvCustsales.PageCount%>
                                        </i>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                            Height="37px" OnClick="btnExport_Click" /></div>
                                </div>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvCustsales" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Updatepnel">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="~/images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
