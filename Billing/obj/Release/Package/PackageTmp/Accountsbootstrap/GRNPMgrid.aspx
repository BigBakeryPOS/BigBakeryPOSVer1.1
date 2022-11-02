<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRNPMgrid.aspx.cs" Inherits="Billing.Accountsbootstrap.GRNPMgrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>GRN (+)(-)</title>
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
<body style="" >
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                     <form id="Form1" runat="server">
                     <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
             

                                <div class="form-group">
                                <h2>Search By Item</h2>
                                <asp:DropDownList CssClass="form-control" ID="ddlfilter" style="width:150px;" runat="server">
                                           <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Item Name" Value="1"></asp:ListItem>
                                            
                                                </asp:DropDownList>

                                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" style="width: 150px;margin-left: 165px;margin-top: -35px;"></asp:TextBox>
                                    <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label>
                                </div>


                                    <div class="form-group">
                                    
                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" style="margin-top: 10px;"  OnClick="Search_Click"  /> 

                                    <asp:Button ID="btnreset" runat="server" class="btn btn-warning" Text="Reset" style="margin-top: 10px;" OnClick="Reset_Click"  /> 
                                    <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" style="margin-top: 10px;" onclick="btnadd_Click" />
                                    </div>
                                        <div class="form-group">
                                        
                                        </div>
                                        <asp:Button ID="btnTransfer" runat="server" class="btn btn-success" 
                                        Text="Transfer" style="margin-top: 10px;display:none" onclick="btnTransfer_Click"  />
										<div >
                                        
                                <table style="background-color:#ffcc00" >
                                <tr>
                                <td colspan="4" align="center">
                                <asp:GridView ID="gridview" runat="server" AllowPaging="true" PageSize="30"   
                                        OnPageIndexChanging="Page_Change"  AutoGenerateColumns="false"  
                                        CssClass="myGridStyle" onrowcommand="gvstock_RowCommand"
                                      >
                                <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1"  Mode="Numeric"  />
                                <Columns>
                                
                                    <asp:BoundField HeaderText="Group " DataField="category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                                    <asp:BoundField HeaderText="Quantity" DataField="Grn_Qty"/>
                                    
                             
    
    </Columns>
  
 <FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
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
                Stock List</div>
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
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		

</body>
</html>

