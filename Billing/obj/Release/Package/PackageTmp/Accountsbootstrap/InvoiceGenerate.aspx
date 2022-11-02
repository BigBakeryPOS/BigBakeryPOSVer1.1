<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceGenerate.aspx.cs"
    Inherits="Billing.Accountsbootstrap.InvoiceGenerate" EnableEventValidation="false" %>

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
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Sales Type Report</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .Hide
        {
            display: none;
        }
        
        
        .myGridStyle
        {
            font-family: "Comic Sans MS";
            border-collapse: collapse;
            font-names: "Comic Sans MS";
            rowstyle-borderstyle: "Double";
            headerstyle-horizontalalign: "Center";
            font-weight: "bold";
        }
    </style>
</head>
<body style="">
    <form runat="server" id="form1" method="post">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:TextBox ID="txtemail" Visible="false" runat="server" Text="nknavaneethan4U@gmail.com,sriniavl@mirufood.com"></asp:TextBox>
    <%--Text="nknavaneethan4U@gmail.com,sriniavl@mirufood.com"--%>
    <asp:TextBox ID="txtdelorderemail" Visible="false" runat="server" Text="blaackforestonline@gmail.com"></asp:TextBox>
    <asp:Label ID="repdays" runat="server" Visible="false" Text="60"></asp:Label>
    <div class="row" style="padding-top: 15px">
        <div class="row" style="padding-left: 25px">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Invoice Generate For Sales</h3>
            </div>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="col-lg-1">
            <div class="form-group">
                <asp:Label ID="lblpaymode" runat="server" Visible="false" Text="s.ipaymode <> ('15')"></asp:Label>
                <label style="color: #428bca">
                    From Date</label>
                <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="--Select Date--"></asp:TextBox>
                <%-- <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtfrmdate"
                    ErrorMessage="Please enter From Date!" Text="" Style="color: White" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfrmdate"
                    Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
        <div id="Div2" class="col-lg-1" runat="server" visible="true">
            <div class="form-group">
                <label style="color: #428bca">
                    To Date</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txttodate">
                </asp:TextBox>
                <%-- <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txttodate"
                    runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="form-group" runat="server" visible="false">
                <label style="color: #428bca">
                    Category</label>
                <asp:DropDownList ID="ddlsalestype" runat="server" class="form-control" Width="150px"
                    Visible="true">
                    <asp:ListItem Text="Sales" Value="1" Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlcat" runat="server" class="form-control" Width="150px" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-1">
            <label style="color: #428bca">
                Admin Password</label>
            <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" CssClass="form-control"
                placeholder="Enter your Password" AutoPostBack="true" OnTextChanged="txtpassword_OnTextChanged"></asp:TextBox>
        </div>
      
       <div class="col-lg-2">
            <label style="color: #428bca">
                Select Branch</label>
            <asp:DropDownList ID="ddlbranch" AutoPostBack="true" runat="server" class="form-control">
            </asp:DropDownList>
        </div>

        <div class="col-lg-2">
            <div class="form-group">
                <br />
                <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-success"
                    Text="Generate Report" OnClick="Search_Click" Style="width: 120px; background-color: #428bca" />
            </div>
        </div>
        <div id="Div3" class="col-lg-1" runat="server">
            <div class="form-group">
                <br />
                <asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-danger"
                    Text="Excel" OnClick="btnexcel_Click" Style="width: 120px" />
            </div>
        </div>
        <div class="col-lg-2">
            <br />
            <asp:RadioButtonList ID="radbtn" runat="server">
                <asp:ListItem Text="Sales" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Order Form" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-lg-1">
            <br />
            <asp:Button ID="btnsave" Visible="true" runat="server" class="btn btn-warning" Text="Email "
                OnClick="Email_Click" Style="width: 120px" />
        </div>
         
    </div>
    <div class="col-lg-12">
        <div class="row" style="padding-top: 10px">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div runat="server" visible="false" class="col-lg-4">
                            <asp:GridView ID="gvinvoice" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                                OnRowCommand="gvinvoice_OnRowCommand" EmptyDataText="No Record found" Width="100%"
                                ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="100">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="InvoiceNo" DataField="InvoiceNo" />
                                    <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField HeaderText="Amount" DataField="FINALAMOUNT" DataFormatString="{0:f}" />
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("InvoiceNo") %>' CommandName="ViewDate"
                                                Text="View" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div align="center" class="col-lg-8">
                            <div id="div1" runat="server">
                                <table border="1">
                                    <tr runat="server" visible="false">
                                        <td>
                                        </td>
                                        <td>
                                            Blaack Forest
                                            <br />
                                            No.12, Lake View Road,
                                            <br />
                                            KK Nagar, Madurai - 625020
                                            <br />
                                            Phone No. 99433 63525
                                            <br />
                                            GSTIN: 33AWBPR0957L1ZA
                                            <br />
                                        </td>
                                        <td>
                                            <b>Details of Buyer: </b>
                                            <br />
                                            Keestu Mithai
                                            <br />
                                            No.E 29 & 30, Bharathiyar Shopping Complex
                                            <br />
                                            Periyar Bus Stand, Madurai - 625001
                                            <br />
                                            GSTIN: 33AASFK2747C1ZD
                                            <br />
                                        </td>
                                        <td>
                                            Inv.No.<asp:Label ID="lblinvoiceno" runat="server"></asp:Label>
                                            <br />
                                            Date :<asp:Label ID="lblinvoicedate" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                                                OnRowDataBound="gvSalesValue_OnRowDataBound" EmptyDataText="No Record found"
                                                Width="100%" ShowFooter="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                                    <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString='{0:dd/MMM/yyyy}' />
                                                    <asp:BoundField HeaderText="GRN Source" DataField="grnsource" />
                                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Itemname" />
                                                    <asp:BoundField HeaderText="GST%" DataField="GST" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:f}" />
                                                    <asp:BoundField HeaderText="Rate" DataField="rate" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Total Rate" DataField="TotalRate" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Margin%" DataField="Margin" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Margin Value" DataField="Marginvalue" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Basic Cost After Margin" DataField="BasicCostAfterMargin"
                                                        DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="GST Value" DataField="GSTvalue" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                </Columns>
                                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Sales Exempted :
                                            <asp:Label ID="lblsalesexempted" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Taxable Sales :
                                            <asp:Label ID="lbltaxablesales" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            GST :
                                            <asp:Label ID="lblcgst" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td colspan="4" align="right">
                                            SGST :
                                            <asp:Label ID="lblsgst" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            NET AMOUNT :
                                            <asp:Label ID="lblnetamount" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Round Off :
                                            <asp:Label ID="lblroundoff" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            FINAL AMOUNT :
                                            <asp:Label ID="lblfinalamount" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div4" runat="server">
                                <table border="1">
                                    <tr id="Tr1" runat="server" visible="false">
                                        <td>
                                        </td>
                                        <td>
                                            Blaack Forest
                                            <br />
                                            No.12, Lake View Road,
                                            <br />
                                            KK Nagar, Madurai - 625020
                                            <br />
                                            Phone No. 99433 63525
                                            <br />
                                            GSTIN: 33AWBPR0957L1ZA
                                            <br />
                                        </td>
                                        <td>
                                            <b>Details of Buyer: </b>
                                            <br />
                                            Keestu Mithai
                                            <br />
                                            No.E 29 & 30, Bharathiyar Shopping Complex
                                            <br />
                                            Periyar Bus Stand, Madurai - 625001
                                            <br />
                                            GSTIN: 33AASFK2747C1ZD
                                            <br />
                                        </td>
                                        <td>
                                            Inv.No.<asp:Label ID="Label1" runat="server"></asp:Label>
                                            <br />
                                            Date :<asp:Label ID="Label2" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvorder" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                                                OnRowDataBound="gvorder_OnRowDataBound" EmptyDataText="No Record found" Width="100%"
                                                ShowFooter="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                                    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                    <asp:BoundField HeaderText="Payment Date" DataField="Billdate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                    <asp:BoundField HeaderText="Order AMOUNT" DataField="NetAmount" DataFormatString="{0:f}" />
                                                    <asp:BoundField HeaderText="COST" DataField="COST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="GST %" DataField="GST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Pay Type" DataField="paytype" />
                                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Margin%" DataField="marginvalue" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Margin Value" DataField="Margin" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Basic Cost After Margin" DataField="castbeforemargin"
                                                        DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="GST Value" DataField="GSTV" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Net Amount" DataField="NetamountV" DataFormatString='{0:f}'
                                                        ItemStyle-HorizontalAlign="Right" />
                                                </Columns>
                                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Taxable Sales :
                                            <asp:Label ID="lbltaxablesalesorder" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            GST :
                                            <asp:Label ID="lblcgstorder" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server" visible="false">
                                        <td colspan="4" align="right">
                                            SGST :
                                            <asp:Label ID="Label6" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            NET AMOUNT :
                                            <asp:Label ID="lblnetamountorder" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            Round Off :
                                            <asp:Label ID="lblroundofforder" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="right">
                                            FINAL AMOUNT :
                                            <asp:Label ID="lblfinalamountorder" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="col-lg-3">
        </div>
        <div class="col-lg-7">
            <asp:Label runat="server" ID="lblstkreturn" ForeColor="RoyalBlue" Visible="true"> </asp:Label>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    </form>
</body>
</html>
