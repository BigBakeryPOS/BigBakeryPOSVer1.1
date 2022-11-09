<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockRequest.aspx.cs" Inherits="Billing.Accountsbootstrap.StockRequest" MaintainScrollPositionOnPostback="true" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" runat="server">
    <title>Billing</title>
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.2)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.2)" />
     <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
  <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .ddl
        {
            border:2px solid #7d6754;
            border-radius:5px;
            padding:-3px;
            -webkit-appearance: none; 
            background-image:url('Images/Arrowhead-Down-01.png');
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 0.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }
</style>
<style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
   <link href="../Styles/chosen.css" rel="stylesheet" type="text/css" />
</head>
<body>

  <usc:Header ID="Header" runat="server" />   
 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
<form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" EnableViewState="true" UpdateMode="Conditional">
    <ContentTemplate>                
   


      
                        
                    
                            <div class="row">
                               
                                     <div class="form-group" style="text-align:center;margin-top:100px">
                                            <h2>Blaack Forest</h2>
                                           <h4>Daily Stock Form </h4>
                                           
                                           
                                        </div>	    
                                       
                               
                                                                           
										
                                   
                             
                             
                               
                               
                          
                             <table class="table table-bordered table-hover">  
                             <tr>
                            <td style="padding-left:20px">
                            <table><tr>
                             <td><asp:Label runat="server" ID="Label1"  >Production Name </asp:Label>
                                <asp:DropDownList runat="server" ID="ddlvendor" class="form-control" Width="200px" AutoPostBack="true" onselectedindexchanged="ddlvendor_SelectedIndexChanged" 
                                                >
                                           
                                        </asp:DropDownList>    <label id="Error" style="color:Red" runat="server"></label>
                                        
                            </td>
                            <td style="padding-left:20px"><asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" Width="200px" TextMode="MultiLine" Height="70px"></asp:TextBox></td>
                            </tr></table>
                            </td>
                            <td>
                            <asp:Label runat="server" ID="Label3"  >Req No. </asp:Label>
                             <asp:TextBox ID="txtpono" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                     
                            </td>
                            <td>
                               <asp:Label runat="server" ID="Label4"  > Req Date</asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtpodate" Width="100px" runat="server" Text="--Select Date--"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1" ControlToValidate="txtpodate" style="color:Red" ErrorMessage="Enter PO Date"></asp:RequiredFieldValidator><br />
                              
                            </td>
                            </tr>
                            
                            
                            </table>
                          
                               
                                
                                 
                             
                               
                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"  ></asp:ScriptManager>
                               
                               
                                 
                                
                               
                          
                            
                              
                                </div>
                                </div>
                               
                        </ContentTemplate>
                        <Triggers  >
                        <asp:AsyncPostBackTrigger ControlID="ddlvendor" />
                        </Triggers>
                        </asp:UpdatePanel>
                       
                     
                    <asp:UpdatePanel ID="update" runat="server" ChildrenAsTriggers="true" EnableViewState="true" UpdateMode="Conditional">
                        <ContentTemplate>
                         <div >
        <div >
                      <asp:GridView ID="gvcustomerorder" runat="server" 
                          AutoGenerateColumns="False"  CssClass="mGrid"  
                 OnRowDeleting="grvStudentDetails_RowDeleting"
                Width="100%"  Style="text-align: left" onrowdatabound="gvcustomerorder_RowDataBound" 
                >
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="SNo" />
                    <asp:TemplateField HeaderText="Product" >
                        <ItemTemplate>
                            <asp:DropDownList  Width="200px"  CssClass="form-control"  ID="ddlCategory" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlCategort_SelectedIndexChanged"></asp:DropDownList>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:DropDownList    Width="200px"  CssClass="form-control" ID="ddlDef" runat="server" AutoPostBack="true" onselectedindexchanged="ddlDef_SelectedIndexChanged"></asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox Width="200px"   ID="txtQty"  CssClass="form-control" runat="server"  MaxLength="10" ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Units">
                        <ItemTemplate>
                          <asp:DropDownList ID="ddlUnits" runat="server"  CssClass="form-control" Width="150px" >
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                              <asp:ListItem Text="Nos" Value="3"></asp:ListItem>

                          </asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderStyle-Width="100px"   >
               <ItemTemplate   >
               <asp:LinkButton ID="add" runat="server" onclick="btnnew_Click"  ><asp:Image ID="img" Width="20px"   runat="server" ImageUrl="~/images/edit_add.png"  /></asp:LinkButton>

               </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                   
                        <ItemTemplate>
                        <asp:Label id="catid1" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:CommandField  ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/images/delete.png"  />
                </Columns>
              
               
            </asp:GridView>
             </div>
            </div>
              <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script src="Scripts/jquery.min.js" type="text/javascript"></script>
		<script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script type="text/javascript">		    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                  </ContentTemplate>
                        <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="gvcustomerorder" EventName="RowCommand" />
                        
                 
                        
                        
                        </Triggers>
                        </asp:UpdatePanel>
           
            <div  align="center">
            <asp:Button id="btnsave" runat="server" Text="Save" onclick="btnsave_Click1" Height="40px" CssClass="btn btn-success" />
            </div>
            <br />       
            


       
                        
                        <!-- /.panel-body -->
           
                    <!-- /.panel -->
               
                <!-- /.col-lg-12 -->
           

 </form>

 
</body>

</html>
