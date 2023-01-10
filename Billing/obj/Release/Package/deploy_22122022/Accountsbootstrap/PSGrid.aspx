<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.PSGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Purchase Entry Grid </title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

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
    </script>
    
</head> 
<body style="">
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row" style="">
                <div class="col-lg-12" style="">
                    <h1 class="page-header">Daily Stock Request Details</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row" style="">
                <div class="col-lg-12" style="">
                    <div class="panel panel-default" style="">
                        
                        <div class="panel-body" style="">
                            <div class="row" style="">
                                <div style="">
                                
                                    <form runat="server" id="form1" method="post">
                                    <asp:UpdatePanel ID="panel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:scriptmanager id="ScriptManager1" runat="server">
                                              </asp:scriptmanager>
                                    <div class="form-group" style="">
                                            <label>Filter By</label>
                                            <asp:DropDownList ID="ddlbillno" CssClass="form-control" Visible="false" style="width:150px;" 
                                                runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>

                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlVendor" CssClass="form-control" runat="server" style="width:273px;"></asp:DropDownList>
                                                 
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search"  
                                                style="margin-top: 10px;"   /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  
                                                style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add"  
                                                style="margin-top: 10px;" onclick="btnadd_Click" />  
                                        </div> 
                               

                               <div class="table-responsive" style="">
                                        
                                <table class="table table-bordered table-striped" style="">
                                <tr>
                                <td style="">

                                
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="5"  Width="100%" 
                                        AutoGenerateColumns="false" CssClass="myGridStyle" 
                                        onrowcommand="gvPurchaseEntry_RowCommand" 
                                        onrowdatabound="gvPurchaseEntry_RowDataBound" onpageindexchanging="gvPurchaseEntry_PageIndexChanging" 
                                       
                                          >
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings  Mode="Numeric"  />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Production Name" DataField="Production_To" />
     <asp:BoundField HeaderText="Request Date" DataField="RequestDate" />
     <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" Visible="false" />
      <asp:BoundField HeaderText="Status" DataField="Status" />
    <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" />
   

    
     <asp:TemplateField HeaderText="cancel" Visible="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("RequestNO") %>' CommandName="edit"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
     <%--<asp:TemplateField HeaderText="Delete">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>' CommandName="delete" OnClientClick="alertMessage()"><asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>--%>

       <asp:TemplateField HeaderText="View" >
     <ItemTemplate>
           <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RequestNO") %>' CommandName="View" ><asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>
   </Columns>
     
 <FooterStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
   </asp:GridView>
                                </td>
                                <td style="">
                                <asp:GridView ID="gvPurchaseReqDetails" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle">
                                <Columns>
                                <asp:BoundField  HeaderText="Category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="Order Qty" DataField="Order_Qty" />
                               
                                <asp:BoundField  HeaderText="Received Qty" DataField="Received_Qty" />
                                </Columns>
                                  
 <FooterStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
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
