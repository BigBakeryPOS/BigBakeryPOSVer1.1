<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesRegReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.SalesRegReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Master</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
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


        function Diaplay() {
            var div = document.getElementById("div");

            if (div.style.display == "none") {
                div.style.display = "inline";




            }
            else {
                div.style.display = "none";


            }
        }
    </script>
</head>
<body style="">
    <form runat="server" id="form1" method="post">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row" style="padding-top: 50px">
        <div class="row" style="padding-left: 25px">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Sales Register Report</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="col-lg-12">
            <div class="col-lg-2">
                <div id="Div1" align="center" runat="server">
                    <label>
                        Select Branch</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>
                        From Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Style="width: 130px;
                        margin-left: 9px" Text="--Select Date--"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please enter From Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfrmdate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Style="width: 130px"
                        Text="--Select Date--"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <br />
                    <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-success"
                        Text="Search" OnClick="Search_Click" Style="width: 120px" />
                </div>
            </div>
            <div class="col-lg-2">
            </div>
            <div class="col-lg-2">
            </div>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="col-lg-3">
        </div>
        <div class="col-lg-7">
            <asp:Label runat="server" ID="lblstkreturn" ForeColor="Red" Visible="true"> </asp:Label>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="row" style="padding-top: 30px">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-8">
                        <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="100" CssClass="mGrid"
                            DataKeyNames="categoryid" ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound"
                            AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True"
                            OnRowCommand="gvCustsales_RowCommand" Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="categoryid"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <a href="javascript:switchViews('dv<%# Eval("categoryid") %>', 'imdiv<%# Eval("categoryid") %>');"
                                            style="text-decoration: none;">
                                            <img id="imdiv<%# Eval("categoryid") %>" alt="Show" border="0" src="../images/plus.gif" />
                                        </a>
                                        <%# Eval("categoryid")%>
                                        <div id="dv<%# Eval("categoryid") %>" style="display: none; position: relative;">
                                            <asp:GridView runat="server" ID="gvLiaLedger" CssClass="mGrid" GridLines="Both" AutoGenerateColumns="false"
                                                DataKeyNames="categoryid" ShowFooter="true" Width="100%">
                                                <Columns>
                                                    <asp:BoundField HeaderText="categoryid" DataField="categoryid" Visible="false" />
                                                    <asp:BoundField HeaderText="Category" DataField="Category" Visible="false" />
                                                    <asp:BoundField HeaderText="Items" DataField="Definition" />
                                                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                </Columns>
                                                <HeaderStyle BackColor="BlueViolet" ForeColor="White" />
                                            </asp:GridView>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="categoryid" DataField="categoryid" Visible="false" />
                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <%-- <asp:TemplateField HeaderText="Change">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="link" runat="server" Text="Select" CommandName="Change" CommandArgument='<%# Eval("RetNo") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                            </Columns>
                            <HeaderStyle BackColor="BlueViolet" ForeColor="White" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                        </asp:GridView>
                    </div>
                    <div class="col-lg-2">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
