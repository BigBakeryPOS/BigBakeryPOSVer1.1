<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerKotReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.customerKotReport" %>

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
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("divPrint");
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important; size: landscape;">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();

            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
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
          <h1 class="page-header">Customer Sales Report</h1>
	    </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <label>
                                        Filter By Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                   
                                    <asp:DropDownList ID="drptype" runat="server" OnSelectedIndexChanged="drppayment_selectedindex" Visible="false"
                                        AutoPostBack="true" CssClass="form-control">
                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Cancel" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                   </div>
                                   <div class="col-lg-3"> 
                                    <label>
                                        From date</label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate" class="form-control">
                                    </asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                    </asp:RangeValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                    <label>
                                        To date</label>
                                    <asp:TextBox runat="server" ID="txttodate" AutoPostBack="true" OnTextChanged="txttodate_TextChanged" class="form-control">
                                    </asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                    </asp:RangeValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                    <asp:Button ID="btnall" runat="server" Text="Generate Report" CssClass="btn btn-primary pos-btn1"
                                        OnClick="btnall_Click" />
                                    <asp:CheckBox ID="chkDiscout" Visible="false" runat="server" Text="Check Discount Sales" />
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnViewAll" runat="server" Text="Print" CssClass="btn btn-secondary"
                                        OnClick="Button2_Click" />
                                       &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                             OnClick="btnExport_Click" />
                                </div>
                                <div class="col-lg-12">
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                    <div class="table-responsive panel-grid-left" id="divPrint">
                                     
                                                    <asp:Label ID="lblCaption" runat="server"></asp:Label>
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                    <asp:GridView ID="gvCustsales" runat="server" AllowPaging="false" cssClass="table table-striped pos-table" Width="100%"
                                                        DataKeyNames="KotNo" ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound" padding="0" spacing="0" border="0"
                                                        AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="KotNo"
                                                                HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript:switchViews('dv<%# Eval("KotNo") %>', 'imdiv<%# Eval("KotNo") %>');"
                                                                        style="text-decoration: none;">
                                                                        <img id="imdiv<%# Eval("KotNo") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                                    </a>
                                                                    <%# Eval("KotNo")%>
                                                                    <div id="dv<%# Eval("KotNo") %>" style="display: none; position: relative;">
                                                                        <asp:GridView runat="server" ID="gvLiaLedger" cssClass="table table-striped pos-table"  GridLines="Both" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                                                            ShowFooter="true">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Item" DataField="Item" />
                                                                                <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Tax" DataField="tax" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="KotDate" DataField="KotDate" />
                                                            <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Tax" DataField="tax" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="type" DataField="type" />
                                                            <asp:BoundField HeaderText="Status" DataField="Status" />
                                                        </Columns>
                                                      <%--  <HeaderStyle BackColor="#428bca" ForeColor="White" />--%>
                                                     <%--   <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                             <PagerStyle CssClass="pos-paging" />
                                                    </asp:GridView>
                                                    Total Net amount:<label id="lblTotal" runat="server"></label>
                                                <br />
                                                    Total Tax amount:<label id="disc" runat="server"></label>
                                               <br />
                                                    Total amount:<label id="gndtotal" runat="server"></label>
                                               
                                    </div>
                                    <div style="color: #007aff";  class="col-lg-3">
                                        <label id="lblNoRecords">
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvCustsales" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Updatepnel">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/Fancy pants.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
