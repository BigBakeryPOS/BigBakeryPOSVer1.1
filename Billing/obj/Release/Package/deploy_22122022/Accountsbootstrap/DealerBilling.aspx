<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerBilling.aspx.cs" Inherits="Billing.Accountsbootstrap.DealerBilling" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/DealerMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Dealer Billing</title>
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
<body style="background-color:#95af3a">
<usc:Header ID="Header" runat="server" />
    
    
 
          
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <asp:Label ID="lblstockid"  runat="server" Visible="false"></asp:Label>
 
 
            <div class="row" align="center">
                <div class="col-lg-12">
                    <h1 class="page-header">Invoice</h1>
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
                                            <label  >Select Dealer</label>
											<asp:DropDownList ID="ddlStore" AutoPostBack="true" runat="server" Width="150px" OnSelectedIndexChanged="ddlchanged"  CssClass="form-control"
                                                 >
                                                
                                                
                                                </asp:DropDownList>
                    <label id="err" runat="server" style="color:Red;font-size:medium"   ></label>
                                        </div>
                                     <div class="col-lg-3">
                                     <label   >Bill Date</label>
                                    <asp:TextBox ID="txtdate" runat="server" Enabled="false" Width="150px"  CssClass="form-control"></asp:TextBox>
                                    </div>

                                        <div class="col-lg-3">
                                        <label   > Invoice Made By</label>
                                    <asp:TextBox ID="txtRequestBy" runat="server" Enabled="true" Width="150px" CssClass="form-control"  ></asp:TextBox>
                                    </div>
                                     <div class="col-lg-3">
                                     <label   >Bill No</label>
                                    <asp:TextBox ID="txtReqNo" runat="server" Enabled="false"  Width="150px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
										</div>
                                       
                                        <table class="table" style="background-color:#5bc7fe"  >
                                        <tr>
                                        <td>
                                        <label ">Select Group</label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcat_selectedindexchanged"   AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                          <td>
                                        <label >Select Item</label>
                                        <asp:DropDownList ID="ddlitem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlitem_selectedindexchanged" AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                          <td>
                                        <label >Rate</label>
                                       <asp:TextBox ID="txtrate" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                          <td>
                                        <label >Order Qty</label>
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="form-control" OnTextChanged="txtqtytextchanged" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label >Basic Price</label>
                                        <asp:TextBox ID="txtbasic" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                         <td>
                                        <label >Margin</label>
                                        <asp:TextBox ID="txtmargin" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                         <td>
                                        <label >Sales Exempted</label>
                                        <asp:TextBox ID="txtexempted" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label >Sales @ 5%
</label>
                                        <asp:TextBox ID="txtNet" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label >VAT 5%
</label>
                                        <asp:TextBox ID="txtvat" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label >Total Sales
</label>
                                        <asp:TextBox ID="txttotal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                        <label>Add</label>
                                        <asp:ImageButton ID="img" runat="server" CssClass="img-responsive" ImageUrl="~/images/edit_add.png" OnClick="add_click"  />
                                        </td>
                                        </tr>
                                       
                                       

                                        </table>
                                        <table width="100%" style="background-color:White" >
                                        <tr>
                                        <td>
                                        <asp:GridView ID="gvItems"  HeaderStyle-BackColor="#34a853" HeaderStyle-ForeColor="White"  HeaderStyle-Height="30px"  runat="server" Width="100%" OnRowDeleting="OnRowDeleting" OnRowDataBound = "OnRowDataBound" >
                                        <Columns>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Image"  DeleteImageUrl="~/images/delete.png" />
                                      
                                        </Columns>
                                        </asp:GridView>
                                        </td>
                                        </tr>
                                        </table>
                                        <table width="100%" style="background-color:#3e78a6" >
                                        <tr>
                                        <td></td>
                                        </tr>
                                        <tr>
                                        <td style="Width:160px"></td>
                                        <td style="Width:160px"></td>
                                        <td style="Width:160px"></td>
                                        <td style="Width:160px"></td>
                                        <td style="Width:160px"></td>
                                        <td style="Width:160px"></td>
                                        <td >
                                        <asp:TextBox ID="txtexpTotal" Enabled="false" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                           <td >
                                        <asp:TextBox ID="txtNetTotal" Enabled="false" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                           <td >
                                        <asp:TextBox ID="txtvattotal" Enabled="false" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                           <td >
                                        <asp:TextBox ID="txtgrandtotal" Enabled="false" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>
                                          <asp:Button ID="btnAdd" runat="server" class="btn btn-success" Text="Save"  
                                            ValidationGroup="val1" onclick="btnAdd_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled=true;"   />
                                        
                                        
                                        <asp:Button ID="btnExit" runat="server" class="btn btn-danger" Text="Exit"  onclick="btndel_Click"   />
                                        </td>
                                        </tr>
                                        </table>
                                      
                                  
                               
                              
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
                                
                            </div>
                          
                        </div>
                       
                    </div>
                  
                </div>
               
            </div>

       

</body>

</html>
