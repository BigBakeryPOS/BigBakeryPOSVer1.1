<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockTransferGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.StockTransferGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Stock Transfer Grid </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
    
    
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
     <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
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
   <style type="text/css">
    .boundfield-hidden {
   display: none;
}
   </style>
   

<!-- sometime later, probably inside your on load event callback -->

   
    </head>
<body>
   <usc:Header ID="Header" runat="server" />
    

    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>

                    <form id="Form1" runat="server">
                    <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
         <div class="row" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body" style="margin-top: 55px;">
                            <div class="row">
                                <div class="col-lg-6">
                                    
                                        
                                            
                                          <div style="color: Green; font-weight: bold">
            <br />
            
        </div>
										<div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>
                                 <label>Accepeted by </label>
                                <asp:TextBox ID="txtsentby" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                <td  >
                                <asp:GridView ID="gridview" Width="80%"  runat="server" style="margin-left: 60px;"  EmptyDataText="No Data found"
                                        
                                        AutoGenerateColumns="false" CssClass="mGrid"  AllowSorting="true" 
                                        AllowPaging="true" PageSize="10" onpageindexchanging="page_change" 
                                        onrowcommand="gridview_RowCommand" onrowdatabound="gridview_RowDataBound"
                                       >
                                   <HeaderStyle BackColor="#990000" />
                                   <PagerSettings FirstPageText="1"  Mode="Numeric"  />
                                   <Columns>      
                                    <asp:BoundField HeaderText="RequestNo" DataField="ReQNo" />                    
                                    <asp:BoundField HeaderText="Category" DataField="category" />
                                    <asp:BoundField HeaderText="Description" DataField="Definition" />
                                      <asp:BoundField HeaderText="SubCat" DataField="SubCategoryID"  ItemStyle-CssClass="boundfield-hidden" HeaderStyle-CssClass="boundfield-hidden" />
                                       <asp:BoundField HeaderText="StockId" DataField="StockID"  ItemStyle-CssClass="boundfield-hidden" HeaderStyle-CssClass="boundfield-hidden"  />
                                        <asp:BoundField HeaderText="TO" DataField="FromStore"   ItemStyle-CssClass="boundfield-hidden" HeaderStyle-CssClass="boundfield-hidden" />
                                         <asp:BoundField HeaderText="Category" DataField="CategoryID"  ItemStyle-CssClass="boundfield-hidden" HeaderStyle-CssClass="boundfield-hidden"  />
                                    <asp:BoundField HeaderText="Quantity" DataField="Qty" DataFormatString='{0:N0}' />
                                    <asp:BoundField HeaderText="RequestFrom" DataField="Branch"   />     
                                    <asp:BoundField HeaderText="Requester Name" DataField="Requestby"   />     
                                    <asp:TemplateField HeaderText ="Accept">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="btnaccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("ReQNo")+";"+Eval("SubCategoryID")+";"+Eval("StockID")+";"+Eval("FromStore")+";"+Eval("Qty")+";"+Eval("CategoryID") %>' ></asp:LinkButton>
                                    </ItemTemplate>
                                    </asp:TemplateField>                             
                                   </Columns>
                                    <FooterStyle BackColor="#990000"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="White" HorizontalAlign="Center" />
                                   </asp:GridView>
                                   </td>
                                   </tr>
                                   </table>

                               
                                
                                </div>
										
									</div>
                                    
                                    <div class="col-lg-6" style="margin-top: 88px;">
                                    <div >
                                    <table>
                                    <tr><td> 
                                   
                                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-success"  Visible="false"
                                        Text="Transfer All" onclick="btnadd_Click"  /></td></tr>
                                    </table>
                                        <h2><label><font color="red"></font></label></h2>
                                
                                </div>
                                    </div>
                                    </div></div></div></div>	
                                </div>
                                 
                               
                                </form>
</body>
</html>
