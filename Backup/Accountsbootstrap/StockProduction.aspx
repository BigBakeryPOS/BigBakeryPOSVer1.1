<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockProduction.aspx.cs" Inherits="Billing.StockProduction" %>
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
    <script>
        function myFunction() {
            document.getElementById("btnAdd").disabled = true;
        }
</script>
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

    var clicks = 0;
    function hello() {
        clicks += 1;
        document.getElementById("clicks").innerHTML = clicks;

        if(clicks>1)
            document.getElementById("btnAdd").disabled = true;
    };
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
</script>
<script language="javascript" type="text/javascript">

    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else

            event.returnValue = false;
    }

</script>
 <script type="text/javascript">
     var specialKeys = new Array();
     specialKeys.push(8); //Backspace
     function IsNumeric(e) {
         var keyCode = e.which ? e.which : e.keyCode
         var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
         document.getElementById("error").style.display = ret ? "none" : "inline";
         return ret;
     }
    </script>
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
        <asp:Label ID="lblstockid"  runat="server" Visible="false"></asp:Label>
 
 
            <div class="row" align="center">
                <div class="col-lg-12">
                    <h1 class="page-header">Daily Stock Request To Production</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                            <form id="Form1" runat="server">
                              <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
                                <div class="col-lg-12">
                                  
                                        <div class="col-lg-3">
                                            <label   >Select Store</label>
											<asp:DropDownList ID="ddlStore" AutoPostBack="true" runat="server" Width="150px"  CssClass="form-control"
                                                >
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="KK Nagar" Value="CO1"></asp:ListItem>
                                                  <asp:ListItem Text="Byepass" Value="CO2"></asp:ListItem>
                                                    <asp:ListItem Text="BB Kulam" Value="CO3"></asp:ListItem>
                                                      <asp:ListItem Text="NPuram" Value="CO4"></asp:ListItem>
                                                        <asp:ListItem Text="Nellai" Value="CO5"></asp:ListItem>
                                                
                                                </asp:DropDownList>
                   
                                    </div>
                                    
                                     <div class="col-lg-3">
                                      <label  CssClass="form-control" >Date</label>
                                    <asp:TextBox ID="txtdate" runat="server" Enabled="false" Width="150px"  CssClass="form-control"></asp:TextBox>
                                    </div>

                                        <div class="col-lg-3">
                                        <label   CssClass="form-control" >Requester name</label>
                                    <asp:TextBox ID="txtOrderBy" runat="server" Enabled="true" Width="150px" CssClass="form-control"  ></asp:TextBox>
                                    </div>
										 <div class="col-lg-3">
                                           <label   CssClass="form-control" >Entry No</label>
                                    <asp:TextBox ID="txtpono" runat="server" Enabled="true" Width="150px" CssClass="form-control"  ></asp:TextBox>
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
                                        <label >Order Qty</label>
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="form-control" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" ></asp:TextBox>
                                        <span id="error" style="color: Red; display: none">* Input digits (0 - 9)</span>
                                        </td>
                                        <td>
                                        <label>Add</label>
                                        <asp:ImageButton ID="img" runat="server" CssClass="img-responsive" ImageUrl="~/images/edit_add.png" OnClick="add_click"  EnableViewState="true"  />
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
                                         onclick="btnAdd_Click" OnClientClick="myFunction()"  />
                                        <script>
                                            function myFunction() {
                                                confirm("PLease Wait a Moment!");
                                            }
</script>
                                        
                                        <asp:Button ID="btnExit" runat="server" class="btn btn-danger" Text="Exit"  onclick="btndel_Click"   />
                                <p>Clicks: <a id="clicks">0</a></p>
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
