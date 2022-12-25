<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockTransfer.aspx.cs" Inherits="Billing.Accountsbootstrap.StockTransfer" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Stock Request</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>

      <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

 
    <style>
			.ontop {
				z-index: 999;
				width: 100%;
				height: 100%;
				top: 0;
				left: 0;
				display: none;
				position: absolute;				
				background-color: #cccccc;
				color: #aaaaaa;
				opacity: .4;
				filter: alpha(opacity = 50);
			}
			#popup {
				width: 300px;
				height: 200px;
				position: absolute;
				color: #000000;
				background-color: #ffffff;
				/* To align popup window at the center of screen*/
				top: 50%;
				left: 50%;
				margin-top: -100px;
				margin-left: -150px;
			}
		</style>
    <style type="text/css">

.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 0;
background-color: Black;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.8;
}
.GridviewDiv {font-size: 100%; font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif; color: #303933;}
.headerstyle
{
color:#FFFFFF;border-right-color:#abb079;border-bottom-color:#abb079;background-color: #df5015;padding:0.5em 0.5em 0.5em 0.5em;text-align:center;
}
</style>
<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
<script type="text/javascript">
    function pop(div) {
        document.getElementById(div).style.display = 'block';
        document.getElementById("btnAdd").click();
    }
    function hide(div) {
        document.getElementById(div).style.display = 'none';
    }
    //To detect escape button
    document.onkeydown = function (evt) {
        evt = evt || window.event;
        if (evt.keyCode == 27) {
            hide('popDiv');
        }
    };
		</script>
</head> 
<body>
<usc:Header ID="Header" runat="server" />
    
    
 
          <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <asp:Label ID="lblstockid"  runat="server" Visible="false"></asp:Label>
 
 
            <div class="row" align="center">
                <div class="col-lg-12">
                    <h1 class="page-header">Stock Request</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div id="popDiv" class="ontop">
			<table border="1" id="popup" style="background-color:Red">
            <tr>
            <td align="center" style="color:White">
        <b>Please Wait.................</b>    
            </td>
            </tr>
				
			</table>
		</div>
            <!-- /.row -->
            <div class="row" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                            <form id="Form1" runat="server">
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
                                <div class="col-lg-12">
                                    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
                                    <div class="col-lg-12">
                                        <div class="col-lg-3">
                                            <label  >Select Store</label>
											<asp:DropDownList ID="ddlStore" AutoPostBack="true" runat="server" Width="150px"  CssClass="form-control"
                                                onselectedindexchanged="ddlStore_SelectedIndexChanged" >
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="KK Nagar" Value="CO1"></asp:ListItem>
                                                  <asp:ListItem Text="Byepass" Value="CO2"></asp:ListItem>
                                                    <asp:ListItem Text="BB Kulam" Value="CO3"></asp:ListItem>
                                                      <asp:ListItem Text="NPuram" Value="CO4"></asp:ListItem>
                                                        <asp:ListItem Text="Nellai" Value="CO5"></asp:ListItem>
                                                         <asp:ListItem Text="Purasaivakam" Value="CO7"></asp:ListItem>
                                                          <asp:ListItem Text="Maduravayol" Value="CO6"></asp:ListItem>
                                                
                                                </asp:DropDownList>
                    
                                        </div>
                                     <div class="col-lg-3">
                                     <label   >Date</label>
                                    <asp:TextBox ID="txtdate" runat="server" Enabled="false" Width="150px"  CssClass="form-control"></asp:TextBox>
                                    </div>

                                        <div class="col-lg-3">
                                        <label   >Requester name</label>
                                    <asp:TextBox ID="txtRequestBy" runat="server" Enabled="true" Width="150px" CssClass="form-control"  ></asp:TextBox>
                                    </div>
                                     <div class="col-lg-3">
                                     <label   >Req No</label>
                                    <asp:TextBox ID="txtReqNo" runat="server" Enabled="false"  Width="150px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
										</div>
                                       
                                        <table class="table"  >
                                        <tr>
                                        <td>
                                        <label ">Select Group</label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcat_selectedindexchanged" AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                          <td>
                                        <label >Select Item</label>
                                        <asp:DropDownList ID="ddlitem" runat="server" CssClass="form-control" OnSelectedIndexChanged="dditem_selectedindexchanged" AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                          <td>
                                        <label >Available Qty</label>
                                       <asp:TextBox ID="txtAvlQty" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                          <td>
                                        <label >Order Qty</label>
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label>Add</label>
                                        <asp:ImageButton ID="img" runat="server" CssClass="img-responsive" ImageUrl="~/images/edit_add.png" OnClick="add_click"  />
                                        </td>
                                        </tr>
                                       
                                       

                                        </table>
                                        <table width="100%" style="overflow:scroll" ">
                                        <tr>
                                        <td>
                                        <asp:GridView ID="gvItems" CssClass="mGrid" runat="server" Width="100%" OnRowDeleting="OnRowDeleting" OnRowDataBound = "OnRowDataBound" >
                                        <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                      
                                        </Columns>
                                        </asp:GridView>
                                        </td>
                                        </tr>
                                        </table>
                                      
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-success" Text="Send"  
                                            ValidationGroup="val1" onclick="btnAdd_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled=true;"   />
                                        
                                        
                                        <asp:Button ID="btnExit" runat="server" class="btn btn-danger" Text="Exit"  onclick="btndel_Click"   />
                               
                                <!-- /.col-lg-6 (nested) -->
                          </ContentTemplate>
   </asp:UpdatePanel>
   <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
<img alt="" src="../images/Preloader_10.gif" />
</div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
                                </form>
                                <!-- /.col-lg-6 (nested) -->
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
      
        <!-- /#page-wrapper -->
		
		
		
		<!-- jQuery -->
       

</body>

</html>
