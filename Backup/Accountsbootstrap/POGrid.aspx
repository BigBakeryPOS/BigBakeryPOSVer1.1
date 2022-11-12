 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POGrid.aspx.cs" Inherits="Billing.POGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Category Grid </title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
    <link href="../Styles/chosen.css" rel="Stylesheet" />
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

                    <form id="Form1" runat="server">
                    
         <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body" style="margin-top: 55px;">
                            <div class="row">
                                <div class="col-lg-6">
                                    
                                        <div class="form-group">
                                           <h2> Search By Company Name : </h2>
                                            <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" MaxLength="50" style="margin-top: 10px;" ></asp:TextBox>
                                         <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" style="margin-top:10px;" onclick="Btn_Search"    />
                                                <asp:Button ID="btnresret" runat="server" class="btn btn-warning" Text="Reset" style="margin-top:10px;" onclick="Btn_Reset"/>
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" onclick="btnadd_Click" style="margin-top:10px;"/>
                                        </div>
                                        
										<div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gridview" runat="server"  AllowPaging="true" PageSize="5"  OnPageIndexChanging="Page_Change"  AutoGenerateColumns="false" CssClass="myGridStyle" onrowcommand="gvPO_RowCommand">
                                 <HeaderStyle BackColor="#3366FF" />
                                 <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                
                                    <%--<asp:BoundField HeaderText="Category ID" DataField="CategoryID" />--%>
                                    <asp:BoundField HeaderText="Company Name" DataField="companyname" />
                                     <asp:BoundField HeaderText="TinNo" DataField="TinNo" />
                                     <asp:BoundField HeaderText="PO Number" DataField="Pono" />
                                      <asp:BoundField HeaderText="PO Date" DataField="PoDate" />
                                       <asp:BoundField HeaderText="Item Name" DataField="Itemname" />
                                        <asp:BoundField HeaderText="Rate" DataField="Rate" />
                                    
                               <asp:TemplateField HeaderText="View">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit"   CommandArgument='<%#Eval("POno") %>' CommandName="Edit" runat="server"> <asp:Image ID="imdedit"  ImageUrl="~/images/info_button.png" runat="server" /></asp:LinkButton>
    

                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField>
          <asp:TemplateField HeaderText="Print">
     <ItemTemplate>

    <asp:LinkButton ID="btnprint"   CommandArgument='<%#Eval("POno") %>' CommandName="Print" runat="server"> <asp:Image ID="imgprint"  ImageUrl="~/images/print (1).png" width="55px" runat="server" /></asp:LinkButton>
     <%--<asp:LinkButton ID="btndel"   CommandArgument='<%#Eval("PO_Id") %>' CommandName="Del" runat="server"> <asp:Image ID="Image1"  ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>--%>

                               
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField> 
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
</body>
</html>
