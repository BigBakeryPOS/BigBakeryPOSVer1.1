<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBill.aspx.cs" Inherits="Billing.Accountsbootstrap.NewBill" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" >

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
    
    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
</script>
 <style type="text/css">
    .Hide
    {
        display: none;
    }
</style>

<script type="text/javascript">
    function printGrid() {
          var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
    }
    }
</script>
</head>

<body style="">

   <usc:Header ID="Header" runat="server" />  
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script" runat="server"  ></asp:ScriptManager>
     <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    
    <div class="row" style="margin-top:0px">
    <div class="panel panel-default">
    <div  class="panel-body">
    <div class="row">
    <div class="col-lg-6">
    <div class="form-group">
   
    <label>Bill No</label>

    
    <asp:TextBox ID="txtBillNo" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
    
    
   
    
   
    

  
    
  
 
   
    
    <label style="margin-left:200px;margin-top:-60px">Bill Date</label>

    
    <asp:TextBox ID="txtBillDate" CssClass="form-control" Text="-Select Date--" Width="100px" style="margin-left:200px;margin-top:-37px" runat="server"></asp:TextBox>
      <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
    

    </div>
    <div class="form-group">
     <label>Customer Name</label>
   
    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control"></asp:TextBox></div>
   
    </div>
    <div class="col-lg-6">
     <div class="form-group">
    <label> Mobile Number</label>

 <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control">    </asp:TextBox>
    </div>
    <div class="form-group">
    <label> Payment Mode</label>
  
 <asp:DropDownList ID="drpPayment" runat="server" CssClass="form-control">
 <asp:ListItem Text="Cash" Value="1" Enabled="true"></asp:ListItem>
 <asp:ListItem Text="Credit" Value="2" ></asp:ListItem>
 <asp:ListItem Text="Compliment" Value="3" Enabled="true"></asp:ListItem>
 
 </asp:DropDownList>  
    </div>
    </div>
    </div>
        <div class="table-responsive" >
         
       
      
        <table  width="100%" >
        <tr>
        <td>
            <asp:GridView ID="gvcustomerorder" runat="server"  AutoGenerateColumns="False"  Width="100%" 
                 OnRowDeleting="grvStudentDetails_RowDeleting" 
                      
               Style="text-align: left" onrowdatabound="gvcustomerorder_RowDataBound"  
                CssClass="myGridStyle" onselectedindexchanging="gvcustomerorder_SelectedIndexChanging"   
                ><HeaderStyle BackColor="#990100" />
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="SNo" />
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:DropDownList Width="120px"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus"  class="form-control"  ID="ddlCategory" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlCategort_SelectedIndexChanged"></asp:DropDownList>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:DropDownList BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" Width="200px" ID="ddlDef"  class="form-control"  runat="server" AutoPostBack="true" onselectedindexchanged="ddlDef_SelectedIndexChanged"></asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="SubCatID"  ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" >
                        <ItemTemplate>
                           <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText"></asp:Label>
                            
                        </ItemTemplate>
                      
                        
                            
                       
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Available Qty">
                        <ItemTemplate>
                            <asp:TextBox Width="120px"  style="text-align:right"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" class="form-control"  ID="txtExistQty" runat="server" AutoPostBack="true"  MaxLength="10" ontextchanged="txtdefCatID_TextChanged"  ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox Width="120px"  style="text-align:right"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" class="form-control"  ID="txtQty" runat="server" AutoPostBack="true"  MaxLength="10" ontextchanged="txtdefCatID_TextChanged"  ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate" >
                        <ItemTemplate>
                           <asp:TextBox Width="120px"  BackColor="#F6F1DB" style="text-align:right"  ForeColor="#7d6754" Font-Names="Andalus" class="form-control" ID="txtRate" runat="server" AutoPostBack="true"   MaxLength="10" ></asp:TextBox> 
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                           <asp:TextBox Width="120px" style="text-align:right"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" class="form-control" ID="txtAmount" runat="server"  MaxLength="50" ></asp:TextBox>   
                            
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
          <FooterStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#ffcc00"  ForeColor="Black" HorizontalAlign="Center" />
                               
            </asp:GridView>
          
            
              
            </td></tr>
          
            </table>
                <table   >
                  <tr>
            <td >
            <label style="margin-left:870px">sub-Total</label>
           </td>
           <td>
            <asp:TextBox ID="txtSubTotal" runat="server" style="text-align:right" Width="130px"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus"   CssClass="form-control">0</asp:TextBox>
            </td>
            </tr>

             <tr>
            <td>
            <label style="margin-left:870px">Discount</label>
           </td>
           <td>
            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Width="130px"   BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" AutoPostBack="true" style="text-align:right" 
                   ontextchanged="txtDiscount_TextChanged">0</asp:TextBox>
            </td>
            </tr>
              <tr>
            <td>
            <label style="margin-left:870px">Advance</label>
           </td>
           <td>
            <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control" 
                   Width="130px"   BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" 
                   AutoPostBack="true" style="text-align:right" ontextchanged="txtAdvance_TextChanged" 
                   >0</asp:TextBox>
            </td>
            </tr>
              <tr>
            <td>
            <label style="margin-left:870px">Total</label>
           </td>
           <td>
            <asp:TextBox ID="txttotal" runat="server" style="text-align:right" Width="130px"  BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus"   CssClass="form-control">0</asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="center">
            <asp:Button ID="Button1" runat="server" CssClass=" btn btn btn-danger"  Text="Print " OnClientClick="SetTarget();" OnClick="btnSave_Click" />
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
 


     </ContentTemplate>
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="gvcustomerorder" EventName="RowCommand" />
     </Triggers>
    </asp:UpdatePanel>
    </form>
    
</body>
</html>
