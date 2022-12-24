<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaundryBoy.aspx.cs" Inherits="Billing.Accountsbootstrap.LaundryBoy" %>

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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Group Details  </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
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
<body >
    <p>
        good</p>
   <usc:Header ID="Header" runat="server" />
    

    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>

                    <form id="Form1" runat="server">
                    <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
         <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body" >
                            <div class="row">
                                <div >
                                    
                                        <div class="form-group">
                                           <h2>  Laundry Boy Details </h2>
                                           <asp:DropDownList CssClass="form-control" ID="ddlfilter" style="width:130px;" runat="server">
                                           <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Group" Value="1"></asp:ListItem>
                                            
                                                </asp:DropDownList>
                                            <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" MaxLength="50" style="width:150px;margin-top: -34px;margin-left: 155px;" ></asp:TextBox>
                                            <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label>
                                            </div>
                                            <div class="form-group">
                                         <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" style="margin-top:10px;"   />
                                                <asp:Button ID="btnresret" runat="server" class="btn btn-warning" Text="Reset" style="margin-top:10px;" />
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" style="margin-top:10px;"  AccessKey="N"/>
                                        
                                        </div>
                                          <div style="color: Green; font-weight: bold">
         
        </div>
										<div class="table-responsive">
                                        
                                <table class="col-lg-6">
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gridview" runat="server"  CssClass="mGrid"
                                        AllowPaging="true" PageSize="25"   
                                        AutoGenerateColumns="false"  AllowSorting="true"
                                        >
                               
                                 <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                
                                    <%--<asp:BoundField HeaderText="Category ID" DataField="CategoryID" />--%>
                                    <asp:BoundField HeaderText="Group" DataField="category"    />
                                    

                               <asp:TemplateField HeaderText="Edit"    >
     <ItemTemplate>
     <asp:LinkButton ID="btnedit"  ForeColor="White"  CommandArgument='<%#Eval("CategoryID") %>' CommandName="Edit" runat="server"> <asp:Image ID="imdedit"  ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
    

                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField>
          <asp:TemplateField HeaderText="Delete"   >
     <ItemTemplate  >
    
     <asp:LinkButton ID="btndel"   CommandArgument='<%#Eval("CategoryID") %>' CommandName="Del" runat="server"> <asp:Image ID="Image1"  ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
     <ajaxToolkit:modalpopupextender   
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="btndel"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btndel" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>
                                <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                 </ItemTemplate>
    
     
     
     </asp:TemplateField> 
    </Columns>
     
                                </asp:GridView>
                                </td>
                                </tr>
                                
                                </table>

                                
                                
                                </div>
										
									</div>
                                    
                                    <div class="col-lg-6" style="margin-top: 88px;">
                                    <div >
                                        <h2><label><font color="red"></font></label></h2>
                                <table >
                                <tr>
                                <td colspan="4" align="left">
                                    <asp:GridView ID="GVStockAlert" Visible="false" runat="server" AutoGenerateColumns="false" CssClass="mGrid" >
                                    <Columns>
                                <asp:BoundField DataField="Category" HeaderText="Category"  /> 
                                <asp:BoundField DataField="Definition" HeaderText="Definition"  /> 
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity"  /> 
                                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" DataFormatString="{0:n2}" /> 
                                <asp:BoundField DataField="Available_QTY" HeaderText="Available_QTY"  /> 
                                <asp:BoundField DataField="MinQty" HeaderText="MinQty"  /> 
                                   
                                    </Columns>
                                

                                
                                
                                </asp:GridView>
                                </td>
                                </tr>
                                </table>
                                </div>
                                    </div>
                                    </div></div></div></div>	
                                </div>
                                <asp:panel class="popupConfirmation" id="DivDeleteConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Category List</div>
            <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div class="popup_Body">
            <p>
                Are you sure want to delete?
            </p>
        </div>
        <div class="popup_Buttons">
            <input id="ButtonDeleleOkay" type="button" value="Yes" />
            <input id="ButtonDeleteCancel" type="button" value="No" />
        </div>
    </div>
</asp:panel> 
                               
                                </form>
</body>
</html>
