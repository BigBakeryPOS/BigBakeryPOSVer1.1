<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemDetReport.aspx.cs" Inherits="Billing.Accountsbootstrap.ItemDetReport" EnableEventValidation="false" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>
<style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Item Master </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (dropdownchk(document.getElementById('ddlcategory'), "Select Category")
            //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
        && blankchk(document.getElementById('txtdescription'), "Description")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
        

    </script>

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
<body>
  <form id="f1" runat="server">
<usc:Header ID="Header" runat="server" />
    

    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>

                  
                     <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
                    <div class="row">
                <div class="col-lg-12" >
                    <h1 class="page-header">Item Master</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
         <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                          
			<label>Filter By :</label>
				
				
											
                                           <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control"  style="width: 120px">
                                      <asp:ListItem Text="Select by" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Category" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Item" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="S.No" Value="3"></asp:ListItem>
                                          </asp:DropDownList>
                                           <asp:TextBox CssClass="form-control" ID="txtdescription" runat="server" MaxLength="50" style="width: 150px;margin-left: 130px;margin-top: -35px;" ></asp:TextBox>
                                        <asp:Label ID="lblerror" runat="server" style="color:Red"></asp:Label><br />
                                        </div>
                                        
                                        <div class="form-group">
                                            
                                            
                                         <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Search" style="margin-top:10px; " onclick="Button1_Click"    />
                                                <asp:Button ID="Button2" runat="server" class="btn btn-warning" Text="Reset" style="margin-top:8px;" onclick="Button2_Click"/>
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" style="margin-top:8px;" onclick="btnadd_Click"/>
                                        </div>
                                        
                                      
                                         
										<div class="table-responsive" >
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td colspan="4" align="left">
                                <asp:GridView ID="gridview" runat="server" AllowPaging="true" PageSize="50"   Width="100%" 
                                        OnPageIndexChanging="Page_Change" AutoGenerateColumns="false"  
                                        CssClass="myGridStyle" onrowcommand="gvcust_RowCommand" 
                                        onsorting="gridview_Sorting">
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="1" Mode="Numeric" />
                                <Columns>
                                <asp:BoundField HeaderText="Category User ID" DataField="CategoryuserID"  Visible="false"/>
                               
                                    <asp:BoundField HeaderText="Category ID" DataField="CategoryID" Visible="false" SortExpression="Category ID" />
                                    <asp:BoundField HeaderText="Category" DataField="category" SortExpression="category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition"  SortExpression="Definition" />
                                      <asp:BoundField HeaderText="Rate" DataFormatString="{0:###,##0.00}" DataField="Rate"  SortExpression="Definition" />
                                      <asp:BoundField HeaderText="Serial" Visible="false" DataField="Serial" />
                                    <asp:BoundField HeaderText="Serial No" Visible="false" DataField="Serial_No" />
                                      <asp:BoundField HeaderText="Size" DataField="Size" Visible="false" />
                                     <asp:BoundField HeaderText="Description" DataField="CategoryuserID"  SortExpression="Definition" Visible="false" />
                              
    </Columns><FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                                </td>
                                </tr>
                                
                                </table>
                                
                                </div>
									 </div>	
									</div>

                                    <div><asp:Button ID="btnExport" Text="Export to Excel" runat="server" 
                                            CssClass="btn btn-success" Height="37px" onclick="btnExport_Click" /></div>
                                    </div></div></div></div>	
                               
                                 </div>
                                <asp:panel class="popupConfirmation" id="DivDeleteConfirmation" 
	style="display: none" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Description List</div>
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
                            
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
		<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script type="text/javascript">		    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
		
            </form>
</body>

</html>
