<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsReceivedStoreGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.GoodsReceivedStoreGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Store Goods Received Grid </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
        <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');

            prtWindow.document.write(gridData.outerHTML);

            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Store Goods Received</h1>
	    </div>

                <div class="panel-body">
                  
                            <form runat="server" id="form1" method="post">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="row">
                            <div class="col-lg-3">
                                <label>
                                    Select DC NO</label>
                                <asp:DropDownList ID="ddlDC" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlDC_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            </div>
                            <br />
                            <div class="row">
                            <div class="col-lg-6">
                             

                                        <Label>Store Goods Received Details</Label>
                                        <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gvGoodsReceived" Width="100%" runat="server" AllowPaging="true" PageSize="10" cssClass="table table-striped pos-table"
                                                AutoGenerateColumns="false"  OnRowCommand="gvGoodTransFer_RowCommand" padding="0" spacing="0" border="0">
                                               <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                                <PagerSettings Mode="Numeric" />--%>
                                                 <PagerStyle CssClass="pos-paging" />
                                                <Columns>

                                                    <asp:BoundField HeaderText="DC NO" DataField="DC_NO" />
                                                    <asp:BoundField HeaderText="DC Date" DataField="DC_Date" />
                                                    <asp:BoundField HeaderText="Branch RequestNO" DataField="BranchReqNo" />
                                                  <%--    <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" />--%>
                                                    <asp:BoundField HeaderText="Prod RequestNO" DataField="RequestNO" />
                                                    <%--<asp:BoundField HeaderText="Sent From" DataField="Productionname" />--%>
                                                    <%--<asp:BoundField HeaderText="Sent By" DataField="SentBY" />--%>
                                                    <asp:TemplateField HeaderText="Receive">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("DC_NO")+","+ Eval("RequestNO")+","+ Eval("BranchReqNo")%>'
                                                                CommandName="Receive" OnClientClick="alertMessage()">
                                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/receive.png"
                                                                    Width="30px" Height="30px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("DC_NO") %>'
                                                                CommandName="print">
                                                                <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" Visible="false" width="55px"
                                                                    OnClientClick="printGrid()" />
                                                                    <button type="button" class="btn btn-default btn-md">
						                                                <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                                </button>
                                                                    </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnvt" runat="server" CommandArgument='<%#Eval("DC_NO") %>' CommandName="view">
                                                                <asp:Image ID="viw" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false"
                                                                    OnClientClick="printGrid()" />
                                                                    <button type="button" class="btn btn-primary btn-md">
						                                        <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                        </button>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                          
                                            </asp:GridView>
                                 </div>
                                 </div>
                                 <div class="col-lg-6">
                                 
                                       <Label>Store Goods Received Details</Label>
                                       <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gvDetails" runat="server" Width="100%"  AutoGenerateColumns="false" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table">
                                            <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" />--%> 
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="IngreCategory" />
                                                    <asp:BoundField HeaderText="Item" DataField="IngredientName" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Received_Qty" />
                                                    <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" Visible="false" />
                                                </Columns>
                                          
                                            </asp:GridView>
                                     
                            </div>
                            </div>
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </form>
                      
                    </div>
                </div>

    </div>
    </div>
    </div>
    </div>
</body>
</html>
