<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseRequestReports.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PurchaseRequestReports" %>

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
    <title>Daily Request Report Grid </title>
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
    </script>
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
    <%--<script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvPurchaseReqDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            //prtWindow.document.write('<html><head></head>');
            //prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            //prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>--%>
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <h1 class="page-header">
                Daily Stock Request Details</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-default" style="">
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div style="">
                            <form runat="server" id="form1" method="post">
                            <asp:UpdatePanel ID="panel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <div class="col-lg-12">
                                        <div class="col-lg-2">
                                            <label style=" color:#428bca">
                                                From Date</label>
                                            <asp:TextBox runat="server" ID="txtfromdate" Enabled="true" CssClass="form-control"
                                                Width="150px" AutoPostBack="true" OnTextChanged="txttodate_TextChanged">
                                            </asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                            </asp:RangeValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender11" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-2">
                                            <label style=" color:#428bca">
                                                To Date</label>
                                            <asp:TextBox runat="server" ID="txttodate" Enabled="true" CssClass="form-control"
                                                Width="150px">
                                            </asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                            </asp:RangeValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender111" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-primary" Text="Generate Report" Style="margin-top: 25px;"
                                                OnClick="btnadd_Click" />
                                            <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Style="margin-top: 25px;"
                                                OnClick="btnrefresh_Click" />
                                            <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" Style="margin-top: 10px;"
                                                Visible="false" />
                                        </div>
                                        <div class="col-lg-2">
                                        </div>
                                        <div class="col-lg-2">
                                        </div>
                                        <div class="col-lg-2">
                                        </div>
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvPurchaseEntry" runat="server" EmptyDataText="No Record Found"
                                                        PageSize="10" Width="100%" AutoGenerateColumns="false" CssClass="myGridStyle"
                                                        DataKeyNames="RequestNO" OnRowDataBound="gvPurchaseEntry_RowDataBound">
                                                        <HeaderStyle BackColor="#990000" />
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="Req. No."
                                                                HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript:switchViews('dv<%# Eval("RequestNO") %>', 'imdiv<%# Eval("RequestNO") %>');"
                                                                        style="text-decoration: none;">
                                                                        <img id="imdiv<%# Eval("RequestNO") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                                    </a>
                                                                    <%# Eval("RequestNO")%>
                                                                    <div id="dv<%# Eval("RequestNO") %>" style="display: none; position: relative;">
                                                                        <asp:GridView runat="server" ID="gvdetails" CssClass="mGrid" GridLines="Both" AutoGenerateColumns="false"
                                                                            DataKeyNames="TransP_Id">
                                                                            <HeaderStyle BackColor="#990000" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Transid" Visible="false" DataField="TransP_Id" />
                                                                                <asp:BoundField HeaderText="Category" DataField="category" />
                                                                                <asp:BoundField HeaderText="Item Name" DataField="Definition" />
                                                                                <asp:BoundField HeaderText="Order Qty" DataField="Order_Qty" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Production Name" Visible="false" DataField="Production_To" />
                                                            <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString='{0:d}' />
                                                            <asp:BoundField HeaderText="Request Entry Time" DataField="RequestEntryTime" />
                                                            <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" Visible="false" />
                                                            <asp:BoundField HeaderText="Status" DataField="Status" />
                                                            <%--                                                              <asp:BoundField HeaderText="OrderQty" DataField="order_qty" />--%>
                                                            <%-- <asp:TemplateField HeaderText="cancel" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("RequestNO") %>'
                                                                        CommandName="edit">
                                                                        <asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </td>
                                                <%-- <td style="">
                                                    <asp:GridView ID="gvPurchaseReqDetails" runat="server" AutoGenerateColumns="false"
                                                        CssClass="myGridStyle">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Category" DataField="Category" />
                                                            <asp:BoundField HeaderText="Item Name" DataField="Definition" />
                                                            <asp:BoundField HeaderText="Order Qty" DataField="Order_Qty" />
                                                            <asp:BoundField HeaderText="Received Qty" DataField="Received_Qty" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
