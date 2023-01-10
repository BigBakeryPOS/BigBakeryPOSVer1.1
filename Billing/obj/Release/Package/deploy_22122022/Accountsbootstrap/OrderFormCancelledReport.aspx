<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderFormCancelledReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.OrderFormCancelledReport" %>

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
          <h1 class="page-header">OrderForm Cancel Report</h1>
	    </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="col-lg-3">
                                        <div runat="server">
                                            <label>
                                                Select Branch</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>
                                            From date</label>
                                        <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                        </asp:TextBox>
                                        <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" OnTextChanged="txtfromdate_TextChanged"
                                            AutoPostBack="false">  
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                            runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>
                                            To date</label>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txttodate">
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                            runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                        <asp:Button ID="btnall" runat="server" Text="Generate Report" CssClass="btn btn-info pos-btn1"
                                            OnClick="btnall_Click" />
                                    
                                       
                                     &nbsp;&nbsp;&nbsp;       <asp:Button ID="btnExport" Text="Export to Excel" Visible="true" runat="server" CssClass="btn btn-success"
                                                 OnClick="btnExport_Click" />
                                    </div>
                                </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="table-responsive panel-grid-left">
                                        
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="gvOrderForm" runat="server" PageSize="150" cssClass="table table-striped pos-table" AutoGenerateColumns="false"
                                                        EmptyDataText="No data found!" ShowHeaderWhenEmpty="True" padding="0" spacing="0" border="0">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Branch Name" DataField="branch" />
                                                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                            <asp:BoundField HeaderText="Order No" DataField="Orderno" />
                                                            <%--updated 22/10/21 date - no format string was specified b4--%>
                                                            <asp:BoundField HeaderText="Order Date" DataField="OrderDate" DataFormatString='{0:dd/MMM/yyyy  hh:mm:ss tt}' />
                                                            <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                            <asp:BoundField HeaderText="Canceled Date" DataField="CancelDate" DataFormatString='{0:dd/MMM/yyyy  hh:mm:ss tt}' />
                                                            <asp:BoundField HeaderText="Mob No" DataField="MobileNo" />
                                                            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="BookNo" DataField="BookNo" DataFormatString='{0:0}' />
                                                            <asp:BoundField HeaderText="Cancelled By" DataField="Cancelled" DataFormatString='{0:f}' />
                                                        </Columns>
                                                       <%-- <HeaderStyle BackColor="#990000" />--%>
                                                    </asp:GridView>
                                              
                                    </div>
                                </div>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                    
           </div>
           </div>
           </div>
           </div> 
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvOrderForm" EventName="" />
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
