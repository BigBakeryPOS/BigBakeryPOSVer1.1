<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SalesSummaryReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.SalesSummaryReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Report Grid </title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("div1");
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Day Sales & Item Report</h1>
	    </div>
    <div class="panel-body">
    <div class="row">
       <div class="col-lg-12">
            <div class="col-lg-3">
                    <label>
                        From Date</label>
                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" >
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-3">
                
                    <label>
                        To Date</label>
                    <asp:TextBox runat="server" ID="txttodate" CssClass="form-control">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                
            </div>
            <div class="col-lg-6">
                <br />
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info pos-btn1" Text="Search"
                    Width="110px" OnClick="btnSearch_Click" />
           
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExp" runat="server" Text="Export" CssClass="btn btn-success" Width="110px"
                    OnClick="btnexp_Click" />
          
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-secondary"
                    OnClientClick="printGrid()" Width="110px" />
            
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnpdf" runat="server" Text="PDF" CssClass="btn btn-info" OnClick="btnpdf_Click"
                    Width="110px" />
            </div>
      </div>
     
    <div id="div1" runat="server">
        <div class="col-lg-12">
        
        <br />
        <div class="col-lg-12">
            <asp:Label ID="lblheading" runat="server" Font-Bold="true"></asp:Label>
            </div>
            <%--<asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Both" Width="100%">--%>
            <div class="col-lg-6">
            <div class="table-responsive panel-grid-left">
                <asp:GridView ID="GVBillCount" Caption="Bill Count Details" runat="server" EmptyDataText="No Record Found!"
                    OnRowDataBound="GVBillCount_OnRowDataBound" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0"
                    AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Bill Type" DataField="Type" ItemStyle-width="350px" />
                        <asp:BoundField HeaderText="Start Bill" DataField="StartBill" ItemStyle-width="350px" />
                        <asp:BoundField HeaderText="End Bill" DataField="EndBill" ItemStyle-width="350px" />
                        <asp:BoundField HeaderText="Total BillCount" DataField="BillCount" 
                             />
                    </Columns>
                   <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                </asp:GridView>
              </div>
              </div>
              <div class="col-lg-6">
               <div class="table-responsive panel-grid-left">
                <asp:GridView ID="GVCancelBill" Caption="Cancel Bill Count Details" runat="server"
                    EmptyDataText="No Record Found!" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0" AutoGenerateColumns="false"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="CancelBill" DataField="CancelBill" />
                        <asp:BoundField HeaderText="Total BillCount" DataField="BillCount" />
                    </Columns>
                    <%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                </asp:GridView>
                </div>
                </div>
                <div class="col-lg-6">
                 <div class="table-responsive panel-grid-left">
                <asp:GridView ID="GVSalesTaxReport" Caption="Sales Tax Details" runat="server" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0"
                    EmptyDataText="No Record Found!" OnRowDataBound="GVSalesTaxReport_OnRowDataBound"
                     AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tax(%)" DataField="Tax" DataFormatString="{0:f2}" />
                        <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="DisCount" DataField="DisCount" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="CGST" DataField="TaxValue" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="SGST" DataField="TaxValue" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="TotalAmont" DataField="Total" DataFormatString="{0:f2}"
                             />
                    </Columns>
                   <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                </asp:GridView>
               </div>
               </div>
               <div class="col-lg-6">
                <div class="table-responsive panel-grid-left">
                <asp:GridView ID="gvcategorywise" Caption="Category Wise Tax Report" runat="server"
                   cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0" EmptyDataText="No Record Found!" OnRowDataBound="GVcategorywise_OnRowDataBound"
                    AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Category" DataField="Category" DataFormatString="{0:f2}" />
                        <asp:BoundField HeaderText="Tax(%)" DataField="Tax" DataFormatString="{0:f2}" />
                        <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString="{0:f2}"
                            />
                        <asp:BoundField HeaderText="DisCount" DataField="DisCount" DataFormatString="{0:f2}"
                            />
                        <asp:BoundField HeaderText="CGST" DataField="TaxValue" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="SGST" DataField="TaxValue" DataFormatString="{0:f2}"
                             />
                        <asp:BoundField HeaderText="TotalAmont" DataField="Total" DataFormatString="{0:f2}"
                            />
                    </Columns>
                   <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                </asp:GridView>
                </div>
                </div>
                <div class="col-lg-6">
                 <div class="table-responsive panel-grid-left">
                <asp:GridView ID="GridsummaryView" Width="100%" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="gridsummary_rowdatabound" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="" />
                        <asp:BoundField DataField="value" HeaderText="" />
                    </Columns>
                   <%-- <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                    <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />--%>
                </asp:GridView>
                </div>
                </div>
                <div class="col-lg-6">
                 <div class="table-responsive panel-grid-left">
                <asp:GridView ID="GVSalesQtyReport" Caption="Sales Item Qty Details" runat="server"
                    AllowSorting="true" OnSorting="GVSalesQtyReport_OnSorting" OnRowDataBound="GVSalesQtyReport_OnRowDataBound"
                    EmptyDataText="No Record Found!" cssClass="table table-striped pos-table" ShowFooter="true" padding="0" spacing="0" border="0" AutoGenerateColumns="false"
                     Width="100%">
                    <%--<HeaderStyle BackColor="#3366FF" />
                    <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                    <PagerStyle CssClass="pos-paging" />
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Category" DataField="Category"  />
                        <asp:BoundField HeaderText="Item" DataField="Definition"  />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount"  DataFormatString="{0:f2}"  />
                        <asp:BoundField HeaderText="Discount" DataField="Disc"  DataFormatString="{0:f2}"  />
                        <asp:BoundField HeaderText="CGST" DataField="TaxAmount" 
                            DataFormatString="{0:f2}" />
                        <asp:BoundField HeaderText="SGST" DataField="TaxAmount" 
                            DataFormatString="{0:f2}"  />
                        <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" 
                            DataFormatString="{0:f2}"  />
                    </Columns>
                   <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                </asp:GridView>
                </div>
                </div>
                <%--  </asp:Panel>--%>
        </div>
   
    </div>
    </div>
    </div>
     </div>
    </div>
    </div>
    </div>
   
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    </form>
</body>
</html>
