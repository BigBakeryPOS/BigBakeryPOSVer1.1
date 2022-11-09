<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Production_Report.aspx.cs" Inherits="Billing.Accountsbootstrap.Production_Report" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    
    <meta content=""/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Production Report - bootsrap</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
    <link href="../Styles/chosen.css" rel="Stylesheet" />
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
     <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            $find('modalpopup').hide();
            //$get('btnCancel').click();
        }
</script>
<script type="text/javascript">
    function printGrid() {
        var gridData = document.getElementById('<%= gvprodstock.ClientID %>');
        var gridData1 = document.getElementById('<%= gridraw.ClientID %>');
        var windowUrl = 'about:blank';
        //set print document name for gridview
        var uniqueName = new Date();
        var windowName = 'Print_' + uniqueName.getTime();

        var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtWindow.document.write('<html><head></head>');
        prtWindow.document.write('<body style="background:none !important">');
        prtWindow.document.write(gridData.outerHTML);
        prtWindow.document.write(gridData1.outerHTML);
        prtWindow.document.write('</body></html>');
        prtWindow.document.close();
        prtWindow.focus();
        prtWindow.print();
        prtWindow.close();
    }
    </script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                     <form id="Form1" runat="server">
                     <asp:scriptmanager id="ScriptManager1" runat="server">
                        </asp:scriptmanager>
          <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Production Report</h1>
	    </div>           

                        <div class="panel-body">
                            <div class="row">
								
                         <div class="col-lg-3">
                               <Label>Select From Date</Label>
                               <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate"
                                 PopupButtonID="txtdate" EnabledOnClient="true" runat="server" Format="yyyy-MM-dd" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                            </div>
                             <div class="col-lg-3">
                              
                               <Label>Select To Date</Label>
                               <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                 PopupButtonID="txttdate" EnabledOnClient="true" runat="server" Format="yyyy-MM-dd" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>

                              </div>
                               
                                  <div class="col-lg-3">
                                            <label>Group</label>
											<asp:DropDownList ID="ddlcategory" AutoPostBack="true" runat="server" 
                                                        class="form-control" onselectedindexchanged="ddlcategory_SelectedIndexChanged" 
                                                ></asp:DropDownList>
                                        </div >
                              
                          
                              <div class="col-lg-3">
                              <br />
                               <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-primary pos-btn1" Text="Search" 
                                       onclick="btnsearch_Click" />
                               
                               &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnexp" runat="server" onclick="btnexp_Click" CssClass="btn btn-success" Text="Export to Excel">
                               <asp:Image ID="imgexp" runat="server" ImageUrl="~/images/xcel.png"  Width="50px" Height="50px" Visible="false"/>
                               </asp:LinkButton>
                               
                               &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrint" runat="server" onclick="btnPrint_Click" CssClass="btn btn-default" Text="Print">
                               <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png"  Width="50px" Height="50px" Visible="false"/>
                               </asp:LinkButton>
                              </div>
                              </div>
                              <br />
                               <div class="row">
                                <div id="div1" runat="server">
                                
                               <div class="col-lg-6">
                              
                                <label>Production Details</label><br />
                                <asp:Label ID="lblhead" runat="server" ></asp:Label>
                                <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvprodstock" runat="server" Width="100%"  AutoGenerateColumns="false" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table" OnRowDataBound="gvprodstock_OnRowDataBound" ShowFooter="true" >
                                <%-- <FooterStyle BackColor="Red" Font-Bold="true"  ForeColor="White" />--%>
                                <Columns>
                                <asp:BoundField DataField="requestNo" HeaderText="Finish No" />
                                <asp:BoundField DataField="RequestDate" HeaderText="Finish date"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                <asp:BoundField DataField="definition"  HeaderText="Item Name" />
                                <asp:BoundField DataField="readyqty" HeaderText="Production Qty" />
                                <asp:BoundField DataField="damageqty" HeaderText="Damage Qty" />
                                   
                                </Columns>
                 
  <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                </asp:GridView>
                               </div>
                               </div>
                               <div class="col-lg-6">
                               
                                <label>Raw Materials Details</label>
                                <br />
                                <div class="table-responsive panel-grid-left">
                                 <asp:GridView ID="gridraw" runat="server" Width="100%" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table" AutoGenerateColumns="false" OnRowDataBound="gridraw_OnRowDataBound" ShowFooter="true" >
                                 <%--<FooterStyle BackColor="Red" Font-Bold="true"  ForeColor="White" />--%>
                                <Columns>
                                <asp:BoundField DataField="IngredientName" HeaderText="Raw Materials" />
                                <asp:BoundField DataField="qtyused" HeaderText="Qty Used" />
                                </Columns>
                 
  <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                </asp:GridView>
                                </div>
                                </div>
                                </div>
                                </div>
                                <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    
                       </div>
					</div> 
              </div>
           </div>      
     </div>
</form>
                     
</body>
</html>
