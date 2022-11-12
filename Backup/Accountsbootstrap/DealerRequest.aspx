<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerRequest.aspx.cs" Inherits="Billing.Accountsbootstrap.DealerRequest" %>
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
                <div class="col-lg-12">
                    <h1 class="page-header">Stock Master</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
    <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                <div class="form-group">
                                <h2>Search By Sub Category</h2>
                                <asp:DropDownList CssClass="form-control" ID="ddlfilter" style="width:150px;" runat="server">
                                           <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Item Name" Value="1"></asp:ListItem>
                                            
                                                </asp:DropDownList>

                                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" style="width: 150px;margin-left: 165px;margin-top: -35px;"></asp:TextBox>
                                    <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label>
                                </div>


                                    <div class="form-group">
                                    
                                           </div>
                                        
                                        
										<div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped" width="100%">
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gridview" runat="server"   Width="100%"  AllowPaging="true" PageSize="10"   
                                        AutoGenerateColumns="false"  
                                        CssClass="myGridStyle" onrowcommand="gridview_RowCommand" onpageindexchanging="gridview_PageIndexChanging" 
                                      ><PagerSettings Mode="Numeric" FirstPageText="1" />
                                <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                  <asp:BoundField HeaderText="Dealer Name " DataField="CustomerName" />
                                    <asp:BoundField HeaderText="Category " DataField="Category" />
                                    <asp:BoundField HeaderText="Sub Category" DataField="Definition" />
                                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                    <asp:BoundField HeaderText="Dealer Unit Price" DataFormatString="{0:f}" DataField="unitprice" />
                                <asp:TemplateField HeaderText="Transfer">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit"   CommandArgument='<%#Eval("DealerID") %>' CommandName="Edit" runat="server"> <asp:Image ID="imdedit"  ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
    

                               
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
										
									</div>
                                    </div></div></div></div>	
                                </div>
                               
                                </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		

</body>
</html>

