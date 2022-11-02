<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseEntryGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchaseEntryGrid" %>
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
<body>
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row" style="margin-top:50px">
                <div class="col-lg-12" style="padding-top:70px">
                    <h1 class="page-header">Purchase Entry Details</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <form runat="server" id="form1" method="post">
                                    <div class="form-group">
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
                                                style="margin-top: 10px;" onclick="btnsearch_Click"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  
                                                style="margin-top: 10px;" onclick="btnrefresh_Click"  /> 
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" OnClick="Add_Click" style="margin-top: 10px;" />  
                                        </div> 
                               

                               <div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>

                                
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="5"  
                                        AutoGenerateColumns="false" CssClass="myGridStyle" 
                                        onrowcommand="gvPurchaseEntry_RowCommand" 
                                        onpageindexchanging="gvPurchaseEntry_PageIndexChanging"  >
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings  Mode="Numeric"  />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Bill No" DataField="Bill_NO" />
     <asp:BoundField HeaderText="Bill Date" DataField="Bill_Date" />
     <asp:BoundField HeaderText="DC No" DataField="DC_NO" />
      <asp:BoundField HeaderText="DC Date" DataField="DC_Date" />
    <asp:BoundField HeaderText="Vendor Name" DataField="CustomerName" />
   

    <asp:BoundField HeaderText="Total Amount" DataField="TotalAmount"  DataFormatString="{0:f}" />
     <asp:TemplateField HeaderText="View" Visible="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Bill_NO") %>' CommandName="edit"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
     <%--<asp:TemplateField HeaderText="Delete">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>' CommandName="delete" OnClientClick="alertMessage()"><asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>--%>

       <asp:TemplateField HeaderText="View/Print">
     <ItemTemplate>
           <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("Bill_NO") %>' CommandName="print" ><asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>
   </Columns>
     <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
                                </td>
                                </tr>
                                </table>
                                </div>



                                     
                                   
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
            <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
    <ProgressTemplate>
        <div id="overlay">
            <div id="modalprogress">
                <div id="theprogress">
                    <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/Preloader_10.gif" />
                    Please wait...
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

</body>

</html>
