<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElobratedStockReport.aspx.cs" Inherits="Billing.Accountsbootstrap.ElobratedStockReport" %>
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
<body style="background-color:#FFC0CB">
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
                        
                        <div class="panel-body" style="background-color:#FFC0CB">
                            <div class="row">
                                <div >
                                    <h2> Detailed Stock Report</h2>
                                        <div class="form-group">
                                        <label>
                                         Date</label>
                                    <asp:TextBox runat="server" ID="txttodate">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                          
                                            </div>
                                            <div class="form-group">
                                         <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" style="margin-top:10px;" onclick="Btn_Search"    />
                                                
                                     
                                        
                                        </div>
                                          
										
									</div>
                                    
                                    <div class="col-lg-6" >
                                    <div >
                                        <h2><label><font color="red"></font></label></h2>
                                <table >
                               
                                <tr>
                                <td colspan="4" align="left">
                                    <asp:GridView ID="GVStockAlert"  runat="server" CssClass="myGridStyle"  AutoGenerateColumns="false">
                                    <Columns>
                                    <asp:BoundField HeaderText="ItemID" DataField="categoryuserid" />
                               <asp:BoundField HeaderText="Item" DataField="Definition" />
                               <asp:BoundField HeaderText="OpeningStock" DataField="OpeningStock" DataFormatString='{0:N0}' />
                               <asp:TemplateField HeaderText="SalesQty" >
                               <ItemTemplate>
                               <asp:Label ID="lblsalesQty" runat="server"></asp:Label>
                               </ItemTemplate>
                               </asp:TemplateField>
                              <asp:TemplateField HeaderText="GRN Qty" >
                               <ItemTemplate>
                               <asp:Label ID="lblGrn" runat="server"></asp:Label>
                               </ItemTemplate>
                               </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Current Stock" >
                               <ItemTemplate>
                               <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                               </ItemTemplate>
                               </asp:TemplateField>
                                
                                    </Columns>
                                                                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />

                                
                                
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
