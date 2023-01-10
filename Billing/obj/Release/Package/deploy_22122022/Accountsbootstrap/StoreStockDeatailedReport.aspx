<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreStockDeatailedReport.aspx.cs" Inherits="Billing.Accountsbootstrap.StoreStockDeatailedReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Stock Detailed Report </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="../Styles/chosen.css" rel="Stylesheet" />
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
        function printGrid() {
            var gridData = document.getElementById("tbl");
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');

            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');

            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
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
            margin-left: -60px;
        }
        .chkChoice1 td
        {
            padding-left: 100px;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                if ($(this).is(":checked")) {
                    $("[id*=chkcategorylist] input").attr("checked", "checked");
                } else {
                    $("[id*=chkcategorylist] input").removeAttr("checked");
                }
            });
            $("[id*=chkcategorylist] input").bind("click", function () {
                if ($("[id*=chkcategorylist] input:checked").length == $("[id*=chkcategorylist] input").length) {
                    $("[id*=chkAll]").attr("checked", "checked");
                } else {
                    $("[id*=chkAll]").removeAttr("checked");
                }
            });
        });
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Detailed Report</h1>
	    </div>

                <div class="panel-body">
                    <div class="row">
                       
                       
                                <div class="form-group" id="admin" runat="server">
                                    <legend>Filter By Branch</legend>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                           
                            <div class="col-lg-3">
                                <label>Date</label>
                                <asp:TextBox runat="server" ID="txtFrom" CssClass="form-control" >
                                </asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFrom"
                                    ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                </asp:RangeValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtFrom"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>TYPE </label>
                                <asp:DropDownList ID="ddlstcktype" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="+" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="-" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Nil" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label> STOCK TYPE </label>
                                <asp:DropDownList ID="ddlclosingstocktype" runat="server" CssClass="form-control" >
                                    <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="With 0" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="WithOut 0" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label>DISPLAY TYPE</label>
                                <asp:DropDownList ID="ddldisplaytype" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Only Qty" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Only Value" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-lg-3">
                           
                                    <label>Category</label>
                                    <div style="overflow-y: scroll; height: 150px">
                                            <div class="panel panel-default" >
                                    <asp:CheckBox ID="chkAll" Text="Select All" runat="server" />
                                            <asp:CheckBoxList ID="chkcategorylist" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                                                CssClass="chkChoice1" Width="19pc">
                                            </asp:CheckBoxList>
                                        </div>
                                        </div>
                                    <asp:Label ID="lblsuberror" runat="server" Style="color: Red"></asp:Label>
                                
                            </div>
                            <div class="col-lg-3">
                            <br />
                                <asp:Button ID="Button1" runat="server" class="btn btn-info pos-btn1" Text="Search"
                                    OnClick="Button1_Click" />
                          
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" class="btn btn-secondary" Text="Print"
                                    OnClick="Button2_Click" />
                          
                                 &nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-success"  Text="Export Excel"
                                    OnClick="Button3_Click" />
                            </div>
                       
                   
                       
                            <div id="div2" runat="server" class="col-lg-12">
                                            <label id="caption" runat="server" visible="true">
                                            </label>
                                             <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="GVStockAlert" Width="100%" runat="server"  AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                                EmptyDataText="No Records Found" Caption="Stock Detailed Report"  padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="group" />
                                                    <asp:BoundField HeaderText="Item" DataField="Item" />
                                                    <asp:TemplateField HeaderText="OP-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblopstock" 
                                                                runat="server" Text='<%# String.IsNullOrEmpty(Eval("OpeningStock").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("OpeningStock").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblopstockrate" 
                                                                 runat="server" Text='<%#Eval("OpeningStockRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Branch Transfer-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrnstock"  runat="server" Text='<%# String.IsNullOrEmpty(Eval("GRNQty").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("GRNQty").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblgrnstockrate" runat="server" Text='<%#Eval("GRNQtyRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Kitchen Transfer-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrastock"  runat="server" Text='<%# String.IsNullOrEmpty(Eval("TRAQty").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("TRAQty").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lbltrastockrate"  runat="server" Text='<%#Eval("TRAQtyRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GRN-STOCK/P">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrnstockP"  runat="server" Text='<%# String.IsNullOrEmpty(Eval("GRNQtyP").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("GRNQtyP").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblgrnstockrateP"  runat="server" Text='<%#Eval("GRNQtyRateP")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GRN-STOCK/M">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrnstockM"  runat="server" Text='<%# String.IsNullOrEmpty(Eval("GRNQtyM").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("GRNQtyM").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblgrnstockrateM"  runat="server" Text='<%#Eval("GRNQtyRateM")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="INVOICE-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsalestock" runat="server" Text='<%# String.IsNullOrEmpty(Eval("SalesQty").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("SalesQty").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblsalestockrate"  runat="server" Text='<%#Eval("SalesQtyRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RETURN-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblreturnstock"  runat="server" Text='<%# String.IsNullOrEmpty(Eval("Return").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Return").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblreturnstockrate"  runat="server" Text='<%#Eval("ReturnRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CLOSING-STOCK">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblavlstock" Text='<%# String.IsNullOrEmpty(Eval("Available_Qty").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("Available_Qty").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblavlstockrate"  runat="server" Text='<%#Eval("Available_QtyRate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="STOCK +/-">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstockPM"
                                                                runat="server" Text='<%# String.IsNullOrEmpty(Eval("StockPM").ToString()) ?  "" :  string.Format("{0:0.00}",Convert.ToDouble(Eval("StockPM").ToString())) %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblstockratePM" runat="server" Text='<%#Eval("StockRatePM")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                               <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                            </asp:GridView>
                                        </div>
                            </div>
                        
                    
                </div>
           
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>

