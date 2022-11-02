<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterGoodsReceivedGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.InterGoodsReceivedGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Inter Goods Received Grid </title>
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
   
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-default" style="">
            <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Inter Goods Received</b></div>
                    
                    
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div class="col-lg-12" style="">
                            <form runat="server" id="form1" >
                            <asp:UpdatePanel ID="updoanel" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                            <div class="form-group" style="">
                                <label>
                                    Select DC NO</label>
                                <asp:DropDownList ID="ddlDC" Width="200px" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlDC_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="table-responsive " style="">
                                <table class="table table-bordered table-striped">
                                    <tr>
                                        <td  style=" width:50%">
                                        <asp:Label>Inter Goods Received Details</asp:Label>
                                            <asp:GridView ID="gvGoodsReceived" Width="100%" runat="server" AllowPaging="true" PageSize="10" Font-Names="Calibri"
                                                AutoGenerateColumns="false"  OnRowCommand="gvGoodTransFer_RowCommand">
                                               <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                                <PagerSettings Mode="Numeric" />
                                                <Columns>

                                                    <asp:BoundField HeaderText="DC NO" DataField="DC_NO" />
                                                    <asp:BoundField HeaderText="DC Date" DataField="DC_Date" />
                                                    <asp:BoundField HeaderText="From Branch RequestNO" DataField="BranchReqNo" />
                                                    <asp:BoundField HeaderText="From Branch" DataField="FromBranchCode" />
                                                  <%--    <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" />--%>
                                                    <asp:BoundField HeaderText="To Branch RequestNO" DataField="RequestNO" />
                                                    <asp:BoundField HeaderText="To Branch" DataField="ToBranchCode" />
                                                    <%--<asp:BoundField HeaderText="Sent From" DataField="Productionname" />--%>
                                                    <%--<asp:BoundField HeaderText="Sent By" DataField="SentBY" />--%>
                                                    <asp:TemplateField HeaderText="Receive">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("DC_NO")+","+ Eval("RequestNO")+","+ Eval("BranchReqNo")+","+ Eval("ToBranchCode")%>'
                                                                CommandName="Receive" OnClientClick="alertMessage()">
                                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/receive.png"
                                                                    Width="30px" Height="30px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("DC_NO") %>'
                                                                CommandName="print">
                                                                <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px"
                                                                    OnClientClick="printGrid()" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnvt" runat="server" CommandArgument='<%#Eval("DC_NO") %>' CommandName="view">
                                                                <asp:Image ID="viw" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png"
                                                                    OnClientClick="printGrid()" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                          
                                            </asp:GridView>
                                        </td>
                                       <td  style=" width:50%">
                                       <asp:Label>Goods Received Details</asp:Label>
                                            <asp:GridView ID="gvDetails" runat="server" Width="100%"  AutoGenerateColumns="false" Font-Names="Calibri">
                                             <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                                <Columns>
                                                    <asp:BoundField HeaderText="Group" DataField="Category" />
                                                    <asp:BoundField HeaderText="Item" DataField="printitem" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Received_Qty" />
                                                    <asp:BoundField HeaderText="Goods Status" DataField="stt" />
                                                    <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" Visible="false" />
                                                </Columns>
                                          
                                            </asp:GridView>
                                        </td>
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

