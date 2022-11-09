<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KOT.aspx.cs" Inherits="Billing.Accountsbootstrap.KOT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print()" >


                   <form id="Form1" runat="server" role="form">
                    <asp:Panel id="pnlContents" runat="server" >
                   

            <!-- /.row -->
            <div    align="center" >
             
                           <table  width="500px" style="font-size:x-large;font-family:Calibri;font-weight:bold"    >
                           <tr>
                           <td>
                           <h3><b>KOT</b></h3></td>
                           </tr>
                           
                              
                           <tr style="font-size:large;font-weight:bold">
                           <td align="left" style="padding-left:5px">
                           <label>KOT No</label>
                           
                           <asp:Label ID="lblbillno" runat="server"></asp:Label>
                        
                           </td>
                           <td align="right">
                         
                           
                          
                           <asp:Label  ID="lbldate" runat="server"></asp:Label>
                           </td>
                          
                           </tr>
                           <tr>
                           <td>
                            <label ID="mode" runat="server">
                               </label>
                           </td>
                           </tr>
						   <tr><td colspan="2" style="font-size:large;text-decoration: none;	border-bottom: 3px dotted black;"></td></tr>
                           <tr>
                          <td colspan="2" align="center" style="padding-left:5px" >
                             <asp:GridView ID="gvPrint" Width="450px" runat="server"  Font-Bold="true"  AutoGenerateColumns="false" HeaderStyle-Font-Size="Small"   GridLines="None"   >
                          <Columns>
                          <asp:BoundField HeaderText ="Item" DataField="Definition"   HeaderStyle-HorizontalAlign="left"  ItemStyle-Font-Size="Large" />
                          <asp:BoundField HeaderText ="Qty" DataField ="Quantity" DataFormatString="{0:N0}" HeaderStyle-HorizontalAlign="left" ItemStyle-Font-Size="Large"    />
                          <asp:BoundField HeaderText ="Rate" DataField="UnitPrice" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false"  />
                          <asp:BoundField HeaderText ="Amount" DataField="Amount"  HeaderStyle-HorizontalAlign="Right"   ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" Visible="false"/>
                          </Columns>

                          </asp:GridView>
                          </td>
                           </tr>
                           
                           
                            
							
                          
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" > </asp:Label>
                   
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                           </table>
                           
                            

                          
                                      
                                      
                                           
                                            
                                     
                                                                                                                          
                                       
                                           
											
                                            
                                            
                                       
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                      
                                           
                                            
                                      
                                        
                                        
                                       
										
                                    
                               
                               
         
                           
                      
                    <!-- /.panel -->
               
      
        </div>
        
       </asp:Panel>
</form>
</body>
</html>
