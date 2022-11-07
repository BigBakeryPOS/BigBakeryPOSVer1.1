<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LedgerMasterGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.LedgerMasterGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title> </title>
    

   
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
   
   <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />

    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>
    <link href="../css/Pos_style.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    
	<%--<script type="text/javascript" src="../jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar.css"/>--%>

    <!-- Bootstrap Core CSS -->
    <link href="../Styles/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../Styles/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />



</head>
<body>

  <usc:Header ID="Header" runat="server" />  
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                   <form id="Form1" runat="server">
                      
                                 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <%--  <div class="col-lg-12">
                    <h1 class="page-header">Ledger Master</h1>
                </div>--%>
                <!-- /.col-lg-12 -->
            
        <!-- /.row -->  
          <div class="container-fluid">
	   <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Ledger Master
           <span class="pull-right">
          <asp:LinkButton ID="Button1" runat="server" onclick="btnnew_Click">
                                                <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
                                             </asp:LinkButton>
                  
                </span>
          </h1>
	    </div>          
                    
                        <div class="panel-body">
                      
                        
                            <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gvledgrid" runat="server"  AllowPaging="true" PageSize="10"
                                        AutoGenerateColumns="false"   AllowSorting="true"  CssClass="table table-striped pos-table" 
                                        onrowcommand="gvledgrid_RowCommand" onpageindexchanging="Page_Change"  OnRowDataBound="gvledgrid_OnRowDataBound" padding="0" spacing="0" border="0">
                                 
                                 <PagerStyle cssclass="pos-paging" />
                                <Columns>
                                
                                    <%--<asp:BoundField HeaderText="Category ID" DataField="CategoryID" />--%>
                                    <asp:BoundField HeaderText="Ledger" DataField="LedgerName"    />

                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="50px">
                                 <ItemTemplate>
                                 <asp:LinkButton ID="btnedit"   CommandArgument='<%#Eval("LedgerID") %>' cssclass="btn btn-warning btn-md" CommandName="Edit" runat="server"> 
                                 <asp:Image ID="imdedit"  ImageUrl="~/images/edit.png" runat="server" visible="false" width="55px"/>
                                 <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                 </asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Delete"  ItemStyle-Width="50px">
                             <ItemTemplate>
                             <asp:LinkButton ID="btndel"   CommandArgument='<%#Eval("LedgerID") %>' CommandName="Del" runat="server"> 
                             <asp:Image ID="Image1"  ImageUrl="~/images/delete.png" visible="false" runat="server" />
                             <button type="button" class="btn btn-danger btn-md">
									<span class="glyphicon glyphicon-remove"  aria-hidden="true"></span>
							</button>
                              </asp:LinkButton>
                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                             </ItemTemplate>
                        </asp:TemplateField> 
                </Columns>
    
   <%-- <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                </asp:GridView>
                             
         
        
        </div>
        </div>
        <!-- /#page-wrapper -->
		</div>
        </div>
       
        </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>

</html>
