<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Printing_Report.aspx.cs" Inherits="Billing.Accountsbootstrap.Printing_Report" %>
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

    <title>Stock Grid - bootsrap</title>
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
                    <h1 class="page-header">Stock Report</h1>
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
                                <label>Filter By</label>
                                <asp:DropDownList ID="ddlstock" runat="server" CssClass="form-control" 
                                        onselectedindexchanged="ddlstock_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Zero Stock" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Negative Stock" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Minimum Stock" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td  style="padding-top:30px">
                                <asp:Button id="btnsearch" runat="server" Text="Filter" CssClass="btn btn-success" 
                                        onclick="btnsearch_Click" />
                                </td>
                                </tr>
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gvstock" runat="server" AutoGenerateColumns="false" 
                                        AllowPaging="true" CssClass="myGridStyle" PageSize="10" 
                                        onpageindexchanging="page_change" onrowdatabound="gvstock_RowDataBound">
                                  <HeaderStyle BackColor="#3366FF" /><PagerSettings FirstPageText="1" Mode="Numeric" />
                                <Columns>
                                <asp:BoundField HeaderText="Category " DataField="Category" />
                                    <asp:BoundField HeaderText="Sub Category" DataField="Definition" />
                                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                    <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY" />
                                    <asp:BoundField HeaderText="Purchase Price" DataFormatString="{0:f}" DataField="Rate" />
                                    <asp:BoundField HeaderText="Stock Total Price" DataFormatString="{0:f}" DataField="StockAmount" />
                                </Columns>
                                </asp:GridView>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <label>Total Stock Amount</label>
                                </td>
                                <td>
                                <label id="lblstocktotalamt" runat="server"></label>
                                </td>
                                </tr>
                               
                                   <tr>
                                   
                                <td colspan="4" align="left">
                                <asp:GridView Visible="false" ID="gvlowstock" runat="server" AutoGenerateColumns="false" AllowPaging="true"  BackColor="Red" ForeColor="WhiteSmoke">
                          
                                <Columns>
                                <asp:BoundField HeaderText="Category " DataField="Category" />
                                    <asp:BoundField HeaderText="Sub Category" DataField="Definition" />
                                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                    <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY"  />
                                    <asp:BoundField HeaderText="Unit Price" DataFormatString="{0:f}" DataField="unitprice" />
                                </Columns>
                                 <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
                                </td>
                                </tr>
                                </table>
                                
                                </div>
										
									</div> <div class="form-control">
                               <asp:Image ID="imgred" runat="server"  Width="23px" ImageUrl="~/images/Red.png" />-Indicates Out Of Stock
                                <asp:Image ID="imgyellow" runat="server"  Width="20px" ImageUrl="~/images/yellow.png" />-Indicates Below min Qty
                               </div>
                                    </div></div></div></div>	
                                </div>
                                  
                              
                                </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		

</body>
</html>
