<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saleshourreport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.saleshourreport" %>

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
     <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
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
          <h1 class="page-header">Customer Sales Hour's Report</h1>
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
                                   <label>Select Date: </label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName" class="form-control">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate" class="form-control">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                   <%-- <label>
                                        To date</label>--%>
                                    <asp:TextBox runat="server" Visible="false" ID="txttodate" class="form-control">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender  ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                        runat="server"  CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                    <asp:DropDownList ID="ddlTimeFrom" Visible="true" OnSelectedIndexChanged="ddltime_selected" AutoPostBack="true" runat="server" class="form-control">
                                    </asp:DropDownList>
                                  </div>
                                  <div class="col-lg-3">
                                  <br />
                                    <asp:DropDownList ID="ddlTimeTo" Enabled="false" Visible="true" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                    <div class="col-lg-3">
                                    <asp:Button ID="btnall" runat="server"   Text="Generate Report" CssClass="btn btn-primary pos-btn1"
                                        OnClick="btnall_Click" />
                                   
                                         &nbsp; &nbsp; &nbsp;<asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                            OnClick="btnExport_Click" />
                                             &nbsp;
                                    <asp:Button ID="btnViewAll" runat="server" Text="View All" Visible="false" CssClass="btn btn-success"
                                        OnClick="btnViewAll_Click" />
                                </div>
                                </div>
                                <br />
                               
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ></asp:Label>
                                       
                                   
                                    <div class="table-responsive panel-grid-left">
                                       <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ></asp:Label>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="gvCustsales" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                                        runat="server" AllowPaging="true" PageSize="20" AllowSorting="true" cssClass="table table-striped pos-table"
                                                        OnPageIndexChanging="Page_Change" AutoGenerateColumns="false" OnRowCommand="gvcust_RowCommand" padding="0" spacing="0" border="0"
                                                        OnSorting="gvcust_Sorting">
                                                        <PagerStyle CssClass="pos-paging" />
                                                       <%-- <HeaderStyle BackColor="#3366FF" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Time Duration" DataField="Time" />
                                                            <asp:BoundField HeaderText="Total Sales Amount" DataField="Sales-Total" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total Order Amount" DataField="Order-Total" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="Total-Amount" DataFormatString='{0:f}' />
                                                            <%--  <asp:BoundField HeaderText="Sales Type" DataField="SalesType" />--%>
                                                            <%--<asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                                            <asp:BoundField HeaderText="Area" DataField="Area" />
                                                            <asp:BoundField HeaderText="Email" DataField="Email" />--%>
                                                        </Columns>
                                                        <%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                    </asp:GridView>
                                                
                                                 <td runat="server" visible="false">
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="grdorder" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                                        runat="server" AllowPaging="true" PageSize="20" AllowSorting="true" cssClass="table table-striped pos-table"
                                                        OnPageIndexChanging="Page1_Change" AutoGenerateColumns="false" OnRowCommand="grdorder_RowCommand" padding="0" spacing="0" border="0"
                                                        OnSorting="grdorder_Sorting">
                                                        <PagerStyle CssClass="pos-paging" />
                                                        <%--<HeaderStyle BackColor="#3366FF" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Time Duration" DataField="Time" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                             <asp:BoundField HeaderText="Sales Type" DataField="SalesType" />
                                                            <%--<asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                                            <asp:BoundField HeaderText="Area" DataField="Area" />
                                                            <asp:BoundField HeaderText="Email" DataField="Email" />--%>
                                                        </Columns>
                                                       <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                    </asp:GridView>
                                                </td>
                                                <td runat="server" visible="false">
                                                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:GridView ID="grdtotal" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"
                                                        runat="server" AllowPaging="true" PageSize="20" AllowSorting="true" cssClass="table table-striped pos-table"
                                                        OnPageIndexChanging="Page12_Change" AutoGenerateColumns="false" OnRowCommand="grdtotal_RowCommand" padding="0" spacing="0" border="0"
                                                        OnSorting="grdtotal_Sorting">
                                                        <PagerStyle CssClass="pos-paging" />
                                                        <%--<HeaderStyle BackColor="#3366FF" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Time Duration" DataField="Time" />
                                                            <asp:BoundField HeaderText="Total Amount" DataField="Totalamount" DataFormatString='{0:f}' />
                                                            
                                                            <%--<asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                                            <asp:BoundField HeaderText="Area" DataField="Area" />
                                                            <asp:BoundField HeaderText="Email" DataField="Email" />--%>
                                                        </Columns>
                                                       <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                                    </asp:GridView>
                                                </td>
                                            
                                               
                                                    Total:<label id="lblTotal" runat="server"></label>
                                                
                                                    <td visible="false" id="Td1" runat="server" >
                                                    Total:<label id="Label2" runat="server"></label>
                                                </td>
                                                <td id="Td2" runat="server" visible="false" >
                                                    Total:<label id="Label5" runat="server"></label>
                                                </td>
                                           
                                    
                                    </div>
                                    <div runat="server" visible="false" style="color: Green; font-weight: bold" class="form-group">
                                        <label id="lblNoRecords" style="color: Red" runat="server">
                                        </label>
                                        <br />
                                        <i>You are viewing page
                                            <%=gvCustsales.PageIndex + 1%>
                                            of
                                            <%=gvCustsales.PageCount%>
                                        </i>
                                    </div>
                                       <div runat="server" visible="false" style="color: Green; font-weight: bold" class="form-group">
                                        <label id="Label3" style="color: Red" runat="server">
                                        </label>
                                        <br />
                                        <i>You are viewing page
                                            <%=grdorder.PageIndex + 1%>
                                            of
                                            <%=grdorder.PageCount%>
                                        </i>
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
