<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRNPM.aspx.cs" Inherits="Billing.Accountsbootstrap.GRNPM" %>

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
    <title>GRN (+)(-)</title>
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
    <script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvdaygrn.ClientID %>');
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
    </script>
    <script type="text/javascript" language="javascript">
        function printGridNew() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
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
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                GRN (+)(-)</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body" style="">
                    <div class="row">
                        <form id="Form1" runat="server">
                        <asp:ScriptManager ID="script" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="upanel" runat="server">
                            <ContentTemplate>
                                <div class="col-lg-12">
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="txtgrnno" runat="server" Enabled="false" class="form-control" Width="150px"></asp:TextBox>
                                        <div id="admin" runat="server" visible="false" class="form-group">
                                            <label>
                                                Store</label>
                                            <asp:DropDownList ID="ddlstore" AutoPostBack="true" runat="server" class="form-control"
                                                Width="150px">
                                                <asp:ListItem Text="KK nagar" Value="co1"></asp:ListItem>
                                                <asp:ListItem Text="Bye Pass" Value="co2"></asp:ListItem>
                                                <asp:ListItem Text="BB kulam" Value="co3"></asp:ListItem>
                                                <asp:ListItem Text="narayanapuram" Value="co4"></asp:ListItem>
                                                <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                                <asp:ListItem Text="Maduravayol" Value="co6"></asp:ListItem>
                                                <asp:ListItem Text="Purasawalkam" Value="co7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Name</label>
                                            <asp:TextBox ID="txtname" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Category</label>
                                            <asp:DropDownList ID="ddlcategory" AutoPostBack="true" runat="server" class="form-control"
                                                Width="150px" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Sub Category</label>
                                            <asp:DropDownList ID="ddlSubCategory" runat="server" class="form-control" Width="150px"
                                                OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblsuberror" runat="server" Style="color: Red"></asp:Label>
                                        </div>
                                         <label>
                                           Avaliable Qty</label>
                                        <div class="form-group">
                                            <asp:Label ID="lblavastock" runat="server" ></asp:Label>
                                        </div>
                                        <label>
                                            Quantity</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="txtQty" MaxLength="10" Width="150px" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="txtQty" runat="server"
    ErrorMessage="Only Numbers allowed"
    ValidationExpression="\d+">
</asp:RegularExpressionValidator>
                                        </div>
                                        <label>
                                            sign</label>
                                            <asp:RadioButtonList ID="radbtnlist" runat="server" >
                                            <asp:ListItem Text="+" Value="+" Selected="true" ></asp:ListItem>
                                            <asp:ListItem Text="-" Value="-" ></asp:ListItem>
                                            </asp:RadioButtonList>
                                        <div id="AdminPurchaseRate" runat="server" class="Hide">
                                            <label>
                                                Purchase unit Price</label>
                                            <asp:TextBox class="form-control" Enabled="false" ID="txtPurchasePrice" MaxLength="10"
                                                runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="Hide">
                                            <label>
                                                Customer Unit Price</label>
                                            <asp:TextBox CssClass="form-control" ID="txtCustUnitPrice" runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="Hide">
                                            <label>
                                                Dealer Unit Price</label>
                                            <asp:TextBox CssClass="form-control" ID="txtDealerUnitPrice" runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="Hide">
                                            <label>
                                                Press Unit Price</label>
                                            <asp:TextBox CssClass="form-control" ID="txtPressUnitPrice" runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="Hide">
                                            <label>
                                                Minimum Quantity for Stock alert</label>
                                            <asp:TextBox CssClass="form-control" ID="txtminimum" runat="server">0</asp:TextBox>
                                        </div>
                                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                        <asp:Button ID="btnAdd" runat="server" class="btn btn-success" Text="Save" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnExit" runat="server" class="btn btn-warning" Text="Exit" OnClick="btnExit_Click" />
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Style="width: 120px"
                                                Text="--Select Date--"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                                ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                                            <ajaxtoolkit:calendarextender id="CalendarExtender1" targetcontrolid="txttodate"
                                                format="dd/MM/yyyy" runat="server" cssclass="cal_Theme1">
                                            </ajaxtoolkit:calendarextender>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" OnClick="btnsearch_Click" />
                                        <asp:Button ID="btnprint" runat="server" class="btn btn-warning" Text="Print" OnClick="btnprint_Click" />
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddldaygrn" runat="server" class="form-control" Width="150px"
                                                OnSelectedIndexChanged="ddldaygrn_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <div>
                                                <asp:GridView ID="gvdaygrn" CssClass="mGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvPurchaseEntry_RowCommand">
                                                    <HeaderStyle BackColor="#990000" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="id" DataField="id" Visible="false" />
                                                        <asp:BoundField HeaderText="GRNNo" DataField="GRNNo" Visible="false"/>
                                                        <asp:BoundField HeaderText="ToDayGRNNo" DataField="DayGRNmp" />
                                                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                        <asp:BoundField HeaderText="GRNTime" DataField="GRNTimemp" />
                                                        <asp:BoundField HeaderText="GRN_Qty" DataField="GRN_Qty" />
                                                        <asp:BoundField HeaderText="Name" DataField="Name" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" />
                                                        <asp:BoundField HeaderText="Definition" DataField="Definition" />
                                                        <asp:TemplateField HeaderText="Print" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="butPrint" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Print">
                                                                    <asp:Image ID="imgprint" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:GridView>
                                                <asp:GridView ID="GridView1" CssClass="mGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    Visible="true">
                                                    <HeaderStyle BackColor="#990000" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="GRNNo" DataField="GRNNo" Visible="false"/>
                                                        <asp:BoundField HeaderText="ToDayGRNNo" DataField="DayGRNmp" />
                                                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                        <asp:BoundField HeaderText="GRNTime" DataField="GRNTimemp" />
                                                        <asp:BoundField HeaderText="GRN_Qty" DataField="GRN_Qty" />
                                                        <asp:BoundField HeaderText="Name" DataField="Name" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" />
                                                        <asp:BoundField HeaderText="Definition" DataField="Definition" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-1">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!-- /.col-lg-6 (nested) -->
                        </form>
                        <!-- /.col-lg-6 (nested) -->
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
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
</body>
</html>
