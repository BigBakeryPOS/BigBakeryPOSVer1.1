<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemReturngrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ItemReturngrid" %>

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
    <title>Stock Return </title>
    
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
   <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/metisMenu.min.css" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet"/>
    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function alertMessage() {
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvReturnsItem.ClientID %>');
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
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
   <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Return Details
                             <span class="pull-right">
          <asp:LinkButton ID="addbtn" runat="server" onclick="btnAdd_Click">
                   <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD NEW RETURN
			</button>
             </asp:LinkButton>
                </span>
                </h1>
	    </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>
                                From date</label>
                            <asp:TextBox runat="server" ID="txtfromdate" AutoPostBack="true" CssClass="form-control"
                                OnTextChanged="txtfromdate_TextChanged">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <label>
                            To date</label>
                        <asp:TextBox runat="server" ID="txttodate" CssClass="form-control">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                            runat="server" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="col-lg-3">
                        <label>
                            Reasons</label>
                        <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" >
                            <%--<asp:ListItem Text="All" Value="0"></asp:ListItem>
                            <asp:ListItem Text="DateBar" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Damage" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Wrong GRN" Value="5"></asp:ListItem>
                             <asp:ListItem Text="Stock (+)(-)" Value="13"></asp:ListItem>
                            <asp:ListItem Text="Stock Shift" Value="14"></asp:ListItem>
                            <asp:ListItem Text="Stock Consumed" Value="15"></asp:ListItem>--%>
                            <%-- <asp:ListItem Text="Wastage" Value="1" Enabled="false" ></asp:ListItem>--%>
                              <%-- <asp:ListItem Text="Excess" Value="3" ></asp:ListItem>--%>
                            <%--<asp:ListItem Text="Shortage" Value="6" ></asp:ListItem>
  <asp:ListItem Text="Fungus" Value="7" ></asp:ListItem>
  <asp:ListItem Text="Fungus Before Date" Value="8" ></asp:ListItem>
  <asp:ListItem Text="To Production" Value="9" ></asp:ListItem>
   <asp:ListItem Text="Return To Production(Recycle)" Value="10" ></asp:ListItem>
   <asp:ListItem Text="Staff Consumed" Value="11" ></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="12" ></asp:ListItem>--%>
                           
                            <%-- <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="DateBar" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Damage" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Wrong GRN" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Stock (+)(-)" Value="13"></asp:ListItem>
                                                    <asp:ListItem Text="Stock Shift" Value="14"></asp:ListItem>
                                                    <asp:ListItem Text="Stock Consumed" Value="15"></asp:ListItem>--%>
                            <%--
 <asp:ListItem Text="Wastage" Value="1" Enabled="false" ></asp:ListItem>
 <asp:ListItem Text="DateBar" Value="2" ></asp:ListItem>
 <asp:ListItem Text="Excess" Value="3" ></asp:ListItem>
  <asp:ListItem Text="Damage" Value="4" ></asp:ListItem>
  <asp:ListItem Text="Wrong GRN" Value="5" ></asp:ListItem>
  <asp:ListItem Text="Shortage" Value="6" ></asp:ListItem>
  <asp:ListItem Text="Fungus" Value="7" ></asp:ListItem>
  <asp:ListItem Text="Fungus Before Date" Value="8" ></asp:ListItem>
  <asp:ListItem Text="To Production" Value="9" ></asp:ListItem>
   <asp:ListItem Text="Return To Production(Recycle)" Value="10" ></asp:ListItem>
   <asp:ListItem Text="Staff Consumed" Value="11" ></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="12" ></asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <br />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info pos-btn1" Text="Search"
                            OnClick="btnSearch_Click" />
                        
                        &nbsp;&nbsp;&nbsp;
                    
                        <asp:Button ID="btnexport" runat="server" Text="Export to Excel" CssClass="btn btn-success"
                            OnClick="btnexport_Click" />
                    </div>
               </div>
                <div class="row">
                <asp:Label runat="server" ID="lblstkreturn" ForeColor="RoyalBlue" Visible="false"> </asp:Label>
                <div class="col-lg-6">
                <div class="table-responsive panel-grid-left">
                 <asp:GridView ID="gvReturnss" Caption="Returned Goods" runat="server" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0"
                        AutoGenerateColumns="false" OnRowDataBound="gvreturn_rowdatabound"  OnRowCommand="gvReturnss_RowCommand" EmptyDataText="No Records Found" Width="100%" >
                       <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                            HorizontalAlign="Center" ForeColor="White" />--%>
                        <Columns>
                            <asp:BoundField HeaderText="Return No" DataField="RetNo" Visible="true" />
                            <asp:BoundField HeaderText="Date" DataField="ReturnDate" DataFormatString="{0:MM/dd/yy}"
                                ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Total Amount" DataField="Total"  />
                            <asp:BoundField HeaderText="Reason" DataField="Reason" />
                            <asp:BoundField HeaderText="Sub Reason" DataField="SubReasons" />
                            <asp:BoundField HeaderText="SaveDateTime" DataField="saveDateTime" />
                            <asp:BoundField HeaderText="Entry Name" DataField="Name" />
                            <asp:BoundField HeaderText="Detailed Notes" DataField="notes" />
                            
                            
                             <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnviewt" runat="server" CommandArgument='<%#Eval("RetNo") %>'
                                                    CommandName="View">
                                                    <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false" />
                                                    <button type="button" class="btn btn-primary btn-md">
						                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                            </button>
                                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="butPrint" runat="server" CommandArgument='<%#Eval("RetNo") %>'
                                                    CommandName="Print">
                                                    <asp:Image ID="imgprint" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" Width="50px" Visible="false" />
                                                    <button type="button" class="btn btn-default btn-md">
						<span class="glyphicon glyphicon-print" aria-hidden="true"></span>

					</button></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#007aff" ForeColor="black" HorizontalAlign="Center" />
                        <%--<HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                    </asp:GridView>
                </div>
                </div>
                <div class="col-lg-6">
                <div class="table-responsive panel-grid-left">
                    <asp:GridView ID="gvReturnsItem" Caption="Returned Goods" runat="server" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0"
                        AutoGenerateColumns="false" OnRowDataBound="gvReturnsItem_rowdatabound" EmptyDataText="No Records Found" Width="100%">
                        <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                            HorizontalAlign="Center" ForeColor="White" />--%>
                        <Columns>
                            <asp:BoundField HeaderText="Return No" DataField="RetNo" Visible="false" />
                            <asp:BoundField HeaderText="Date" DataField="ReturnDate" DataFormatString="{0:MM/dd/yy}"
                                ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Group" DataField="Category" />
                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                            <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount"  />
                            <asp:BoundField HeaderText="Reason" DataField="Reason" />
                            <asp:BoundField HeaderText="Sub Reason" DataField="SubReasons" />
                            <asp:BoundField HeaderText="SaveDateTime" DataField="saveDateTime" />
                        </Columns>
                        <FooterStyle BackColor="#007aff" ForeColor="black" HorizontalAlign="Center" />
                        <%--<HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                    </asp:GridView>
                    </div>
                    <%--<label>
                        Total Amount:-Rs</label>
                    <label id="lblTotal" runat="server">
                    </label>--%>
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
