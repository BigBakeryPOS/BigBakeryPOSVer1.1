<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductStockHistory.aspx.cs" Inherits="Billing.Accountsbootstrap.ProductStockHistory" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Product Stock History</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
    <link href="../Styles/chosen.css" rel="Stylesheet" />
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
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
                     <div class="row">
                <div class="col-lg-12" style="padding-top:100px">
                    <h1 class="page-header">Product Stock Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
    <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                


                                    
                                        
                                        
										<div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">

                                <tr>
                                <td>
                                <label>Filter By Product Name</label>
                               <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" ></asp:TextBox>
                                </td>
                                <td>
                                <asp:Button id="btnsearch" runat="server" Text="Filter" CssClass="btn btn-success" onclick="btnsearch_Click" 
                                        />
                                </td>
                                 <td>
                                <asp:Button id="btnreset" runat="server" Text="Reset" CssClass="btn btn-danger" onclick="btnreset_Click" 
                                        />
                                </td>
                                </tr>
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gvstock" runat="server" AutoGenerateColumns="false" 
                                        AllowPaging="true" CssClass="myGridStyle" PageSize="10" 
                                        >
                                  <HeaderStyle BackColor="#336699" /><PagerSettings FirstPageText="1" Mode="Numeric" />
                                <Columns>
                                <asp:BoundField HeaderText="Product Name " DataField="Definition" />
                                    <asp:BoundField HeaderText="Size" DataField="size" />
                                    <asp:BoundField HeaderText="Tax %" DataField="Tax" />
                                    <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY" />
                                    <asp:BoundField HeaderText="Purchase Price" DataFormatString="{0:f}" DataField="PurchaseRate" />
                                    <asp:BoundField HeaderText="Dealer Price" DataFormatString="{0:f}" DataField="DealerUnitPrice" />
                                     <asp:BoundField HeaderText="Press Price" DataFormatString="{0:f}" DataField="PressUnitPrice" />
                                      <asp:BoundField HeaderText="Customer Price" DataFormatString="{0:f}" DataField="UnitPrice" />
                                </Columns>
                                </asp:GridView>
                                </td>
                                </tr>
                                                               
                                   
                                </table>
                                
                                </div>
										
									</div> 
                                    </div></div></div></div>	
                                </div>
                                  
                              
                                </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		

</body>
</html>
