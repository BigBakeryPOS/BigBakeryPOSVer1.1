<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemReturn.aspx.cs" Inherits="Billing.Accountsbootstrap.ItemReturn" %>
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
    <title>Billing </title>
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <link href="../css/sb-admin-2.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="../Styles/Gridstyle.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
</head>

<body style="">

    <p>
&nbsp;&nbsp;&nbsp;
    </p>

   <usc:Header ID="Header" runat="server" />  
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
     <asp:UpdatePanel ID="update" runat="server">
    <ContentTemplate>
    
    <div class="row" style="">
    <div class="panel panel-default" style="">
    <div  class="panel-body" style="">
        <div class="table-responsive" style="">

         <div class="panel-body">
                            <div class="row">
                            <div style="">
                            <h2><label>Stock Return</label></h2>
                            </div>
                             <div class="col-lg-2">

            <div class="form-group">
                                            <label>Returning</label>
											<asp:TextBox CssClass="form-control"  Width="50px" ID="txtbillno" Enabled="false" runat="server"></asp:TextBox>
                                            
                                            
                                        </div>
                                       
                                        <div class="form-group">
                                            <label>Bill Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtsdate1" runat="server" Text="-----Select Date-----" Width="150px"  ></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtsdate1"
                                        runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                        </div>
  </div>
   <div class="col-lg-4" >


                                    

                                        <div class="form-group" runat="server" >
                                            <asp:Label runat="server" ID="Label1"  >Production Name </asp:Label>
                                <asp:DropDownList runat="server" ID="ddlvendor" class="form-control" Width="200px" AutoPostBack="true" onselectedindexchanged="ddlvendor_SelectedIndexChanged" 
                                                >
                                           
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" Width="200px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                        <label>Reasons</label>
                                        <asp:DropDownList ID="drpPayment" runat="server" CssClass="form-control">
 <asp:ListItem Text="Wastage" Value="1" ></asp:ListItem>
 <asp:ListItem Text="DateBar" Value="2" ></asp:ListItem>
 <asp:ListItem Text="Excess" Value="3" ></asp:ListItem>
  <asp:ListItem Text="Damage" Value="4" ></asp:ListItem>
  <asp:ListItem Text="Wrong GRN" Value="5" ></asp:ListItem>
  <asp:ListItem Text="Shortage" Value="6" ></asp:ListItem>
  <asp:ListItem Text="Fungus" Value="7" ></asp:ListItem>
  <asp:ListItem Text="Fungus Before Date" Value="8" ></asp:ListItem>
  <asp:ListItem Text="To Production" Value="9" ></asp:ListItem>
   <asp:ListItem Text="Return To Production(Recycle)" Value="10" ></asp:ListItem>
   <asp:ListItem Text="Staff Consumed" Value="11" ></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="12" ></asp:ListItem>
 
 </asp:DropDownList>
                                        </div>
                                        </div>
  </div>
  </div>
  
       
      
        <div class="table-responsive" >
         
       
      
        <table  width="100%" >
        <tr>
        <td>
            <asp:GridView ID="gvcustomerorder" runat="server"  AutoGenerateColumns="False"  Width="100%" 
                 OnRowDeleting="grvStudentDetails_RowDeleting"  CssClass="mGrid"
                      
               Style="text-align: left" onrowdatabound="gvcustomerorder_RowDataBound"  
                onselectedindexchanging="gvcustomerorder_SelectedIndexChanging"   
                >
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="SNo" />
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:DropDownList Width="120px"   class="form-control"  ID="ddlCategory" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlCategort_SelectedIndexChanged"></asp:DropDownList>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:DropDownList  ID="ddlDef"  class="form-control"  runat="server" AutoPostBack="true" onselectedindexchanged="ddlDef_SelectedIndexChanged"></asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="SubCatID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" >
                        <ItemTemplate>
                           <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText"></asp:Label>
                            
                        </ItemTemplate>
                      
                        
                            
                       
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Available Qty">
                        <ItemTemplate>
                            <asp:TextBox Width="120px"  style="text-align:right" Enabled="false"  class="form-control"  ID="txtExistQty" runat="server" AutoPostBack="true"  MaxLength="10" ontextchanged="txtdefCatID_TextChanged"  ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox Width="120px"  style="text-align:right" class="form-control"  ID="txtQty" runat="server" AutoPostBack="true"  MaxLength="10" ontextchanged="txtdefCatID_TextChanged"  ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate" >
                        <ItemTemplate>
                           <asp:TextBox Width="120px"   style="text-align:right" Enabled="false" class="form-control" ID="txtRate" runat="server" AutoPostBack="true"   MaxLength="10" ></asp:TextBox> 
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                           <asp:TextBox Width="120px" style="text-align:right" Enabled="false"  class="form-control" ID="txtAmount" runat="server"  MaxLength="50" ></asp:TextBox>   
                            
                        </ItemTemplate>
                      
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ExpiryDate">
                        <ItemTemplate>
                           <asp:Label ID="lblExpiryDate" runat="server" CssClass="LabelText"></asp:Label>
                            
                        </ItemTemplate>
                      
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField   >
               <ItemTemplate >
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
        <FooterStyle BackColor="#990000"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="White" HorizontalAlign="Center" />
                               
            </asp:GridView>
          
            
              
            </td></tr>
          
            </table>
                <table   >
                  <tr>
            <td >
            <label style="margin-left:870px">sub-Total</label>
           </td>
           <td>
            <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server" style="text-align:right" Width="130px"   CssClass="form-control">0</asp:TextBox>
            </td>
            </tr>

             <tr>
            <td>
            <label style="margin-left:870px">Discount</label>
           </td>
           <td>
            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Width="130px" Enabled="false"   AutoPostBack="true" style="text-align:right" 
                   ontextchanged="txtDiscount_TextChanged">0</asp:TextBox>
            </td>
            </tr>
              <tr>
            <td>
            <label style="margin-left:870px">Advance</label>
           </td>
           <td>
            <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control" Enabled="false"
                   Width="130px"  
                   AutoPostBack="true" style="text-align:right" ontextchanged="txtAdvance_TextChanged" 
                   >0</asp:TextBox>
            </td>
            </tr>
              <tr>
            <td>
            <label style="margin-left:870px">Total</label>
           </td>
           <td>
            <asp:TextBox ID="txttotal" runat="server" Enabled="false" style="text-align:right" Width="130px"    CssClass="form-control">0</asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="center">
            <asp:Button ID="Button1" runat="server" CssClass=" btn btn btn-success"  Text="Return " OnClientClick="SetTarget();" OnClick="btnSave_Click" />
          
            <asp:Button ID="Button2" runat="server" CssClass=" btn btn btn-danger"  
                 Text="Exit " onclick="Button2_Click" />
            </td>
            </tr>
            <tr>
            <td>
            <asp:Label id="lblError" runat="server"></asp:Label>
            </td>
            </tr>
            </table>
            <asp:Panel id="pnlContents" runat = "server">
            <div id="div1">
            <table  width="265px"  id="tblPrint" runat="server" visible="false" >
                           <tr>
                           <td align="center" style="font-size:small">
                           <label>Customer Name:-</label>
                        
                            <asp:Label ID="lblcustname" runat="server">Raja</asp:Label>
                          
                           <label>   Mobile:-</label>
                           
                            <asp:Label ID="lblMobile" runat="server"></asp:Label>
                           </td>
                           </tr>
                           <tr style="font-size:small">
                           <td align="center">
                           <label>Bill No</label>
                           
                           <asp:Label ID="lblbillno" runat="server"></asp:Label>
                        
                            <label >Bill Date:</label>
                          
                           <asp:Label ID="lbldate" runat="server"></asp:Label>
                           </td>
                          
                           </tr>
                           <tr>
                          <td align="center">
                             <asp:GridView ID="gvPrint" runat="server" Width="265px" AutoGenerateColumns="false">
                          <Columns>
                          <asp:BoundField HeaderText ="item" DataField="Definition"  HeaderStyle-HorizontalAlign="Center"/>
                          <asp:BoundField HeaderText ="Qty" DataField ="Quantity" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                          <asp:BoundField HeaderText ="Rate" DataField="UnitPrice" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                          <asp:BoundField HeaderText ="Amount" DataField="Amount" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                          </Columns>

                          </asp:GridView>
                          </td>
                           </tr>
                           <tr>
                           <td align="right" >
                           <asp:Label ID="lblAmount" runat="server"  ></asp:Label>
                           </td>
                           </tr>
                           <tr>
                           <td align="right">
                          <label > Advance:- </label> 
                         
                         <asp:Label ID="lbladvance" runat="server"  ></asp:Label>
                           </td>
                           
                           </tr>
                           <tr>
                           <td align="right" >
                           <label>Total:- </label>
                           
                           <asp:Label ID="lbltotal" runat="server"  ></asp:Label>
                           </td>                          
                            </tr>
                          
                           </table>
            </div>
           </asp:Panel>
              </div>
              </div>
            
        </div>
        </div>
        </div>
    </div>
    </div>
 


     </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="gvcustomerorder" EventName="RowCommand" />
     </Triggers>
    </asp:UpdatePanel>
    </form>
    
</body>
</html>
