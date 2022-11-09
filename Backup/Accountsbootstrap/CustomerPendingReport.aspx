<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPendingReport.aspx.cs" Inherits="Billing.Accountsbootstrap.CustomerPendingReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Pending Report</title>

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

</head> 
<body>
<usc:Header ID="Header" runat="server" />
    



 
  


          <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <form id="Form1" runat="server" role="form">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Receipt page</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="panel-body">
                            <div class="row">
                                

                                                                        

                                
                                <div>
            
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                            <asp:Label ID="lblerrortable" runat="server"  style="color:Red"></asp:Label>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        
                                    </thead>
                                    <tbody>
                                    <tr>
                                    <td>
                                    <h3>Customer Pending Report</h3>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    Select Branch
                                    <asp:DropDownList ID="ddBranch" runat="server"  Width="150px"  AutoPostBack="true"
                                            CssClass="form-control" onselectedindexchanged="ddBranch_SelectedIndexChanged">
                                   <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                   <asp:ListItem Text="Branch 1" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="Branch 2" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="Branch 3" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                        <tr>
                                        <td>
                                        <asp:GridView CssClass="myGridStyle" ID="gvPending" runat="server" 
                                                AutoGenerateColumns="false" onrowcommand="gvPending_RowCommand">
                                        <Columns>
                                        <asp:BoundField HeaderText="Bill No" DataField="billno" />
                                       
                                         <asp:BoundField HeaderText="Customer Name" DataField="Customername" />
                                         
                                            <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString='{0:f}' />
                                           <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount" DataFormatString='{0:f}' />
                                            <asp:BoundField HeaderText="Balance Amount" DataField="Balance" DataFormatString='{0:f}' />
                                          
                                              <asp:TemplateField HeaderText="Pay"> 
                                             <ItemTemplate>
                                             <asp:LinkButton ID="ntnpay" runat="server" CommandName="Pay" CommandArgument='<%#Eval("billno") %>' Text="PAY"></asp:LinkButton>
                                             </ItemTemplate>
                                             </asp:TemplateField>
                                             
                                        </Columns>
                                         <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
                                        
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        <label id="lblCurrent" runat="server">Current Pending From Customers :-</label>

                                        <label id="lblCustpending" runat="server" style="margin-left:150px"></label>
                                        </td>
                                        </tr>
                                    </tbody>
                                </table>
								
                            </div>
							
                                        
										
                            <!-- /.table-responsive -->
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
            <!-- /.row -->
            
        </div>
        <!-- /#page-wrapper -->
		</div>
        </div>
        </div>
        </div>
      
		
		
		<!-- jQuery -->
   </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>

</html>
