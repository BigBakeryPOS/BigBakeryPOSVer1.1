<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesLiveKitchenPrint.aspx.cs" Inherits="Billing.Accountsbootstrap.SalesLiveKitchenPrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script src="../jqueryCalendar/script.js" type="text/javascript"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <script type="text/javascript">
        jQuery(function () {
            jQuery("#inf_custom_someDateField").datepicker();
        });
                

	    
                            
    </script>
    <script type="text/javascript">
        function fixform() {
            if (opener.document.getElementById("aspnetForm").target != "_blank") return;
            opener.document.getElementById("aspnetForm").target = "";
            opener.document.getElementById("aspnetForm").action = opener.location.href;
        }
    </script>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript" language="javascript">
        window.print();
    </script>
</head>
<body onload="window.print()">
    <form id="Form1" runat="server">
    <asp:Panel ID="pnlContents" runat="server">
        <!-- /.row -->
        <div align="center">
            <table width="500px" style="font-size: x-large; font-family: Calibri; font-weight: bold">
                <tr>
                    <td colspan="2" align="center" style="font-size: x-large;">
                        <asp:Label ID="l2" runat="server" Style="font-weight: bolder; font-size: x-large" Visible="false">KOT</asp:Label>
                       <div  id="idimglog" runat="server" visible="true">                  
                       <img width="200px" height="121px" src="../images/BlackForrest.png" style="display:none;"/>
                        <br />
                        </div> <div  id="lblpvtltd" runat="server" visible="false">   
                        <asp:Label ID="lblpvtltd1" runat="server" Text="POTHYS Pvt Ltd" Style="font-weight: bold; font-size: x-large" Visible="false"></asp:Label>
                        <br />
                        </div>
                        <asp:Label ID="lblKOT" runat="server" style="font-size:larger; text-decoration: none; border-bottom: 5px solid black;">KOT</asp:Label>
                        <br />
                        <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size:x-large" Visible="false"></asp:Label>
                        <br />

                        <div  id="idFranchisee" runat="server" visible="false">       
                         <asp:Label ID="Label3" runat="server" Style="font-size: x-large">(Franchisee:Keestu Mithai)</asp:Label>
                         <%--<asp:Label ID="Label2" runat="server" Style="font-size: large">Keestu Mithai</asp:Label>--%>
                        <br />
                        </div>

                        <asp:Label ID="lblAddres" runat="server" Style="font-size: large"></asp:Label>
                    <%--    <br />--%>
                         <asp:Label ID="lblstoreno" runat="server" Style="font-size: x-large;display:none;"></asp:Label>
                      <%--  <br />--%>
                        <asp:Label ID="lblTINNo" runat="server" Style="font-size: large;display:none;">GSTIN:</asp:Label>
                        <asp:Label ID="lbltin" runat="server" Style="font-size: large;display:none;"></asp:Label> <%--<br />--%>
                        
                       

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 5px solid black;">
                    </td>
                </tr>
                <tr visible="false">
                    <td colspan="2" visible="false" align="center" style="font-size: 15px; font-weight: bold">
                        <asp:Label ID="lblcustname" runat="server" style="display:none;"></asp:Label>
                        <asp:Label ID="lblMobile" runat="server" style="display:none;"></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: bold">
                    <td align="left" style="padding-left: 5px">
                        <label>
                            Bill No</label>
                        <asp:Label ID="lblbillno" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="font-size: large; font-weight: bold; display: none">
                    <td align="left" style="padding-left: 5px">
                        <label>
                            B-Code</label>
                        <asp:Label ID="billedby" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <label>
                            A-Code</label>
                        <asp:Label ID="atender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding-left: 5px">
                        <asp:GridView ID="gvPrint" Width="450px" runat="server" Font-Bold="true" AutoGenerateColumns="false"
                            OnRowDataBound="gvPrint_OnRowDataBound" Font-Size="large" GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString="{0:N0}" HeaderStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="  Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center" Visible="false"
                                    ItemStyle-Width="100px" DataFormatString="{0:N2}" />

                                      <asp:BoundField HeaderText="C%" DataField="sg" HeaderStyle-HorizontalAlign="Right" Visible="false"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="S%" HeaderStyle-Width="40px" DataField="cg" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Left" Visible="false" />
                              
                                <asp:BoundField HeaderText="Rate" DataField="UnitPrice" DataFormatString="{0:N2}"
                                    Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td colspan="2" align="right" style="padding-right: 37px">
                        <asp:Label ID="lblAmount" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr id="tradv" runat="server" visible="false" style="font-weight: bold">
                    <td id="Td1" runat="server" visible="false">
                        <label>
                            Paymode:</label>
                        <asp:Label ID="paymode1" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="padding-right: 20px">
                        <label>
                            Advance:-
                        </label>
                        <asp:Label ID="lbladvance" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: x-large; text-decoration: none; border-bottom: 5px solid black;">
                    </td>
                </tr>
                <tr style="font-weight: bold" border="1" id="total" runat="server">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label>
                            Total:-
                        </label>
                        <asp:Label ID="lbltotal" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold" border="1" id="tax" runat="server">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label>
                            Tax 5 %:-
                        </label>
                        <asp:Label ID="lblTax" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                
                 <tr style="" border="1">
                  <td colspan="1" align="left">
                        <label style="font-size: medium">
                            Total Qty :
                        </label>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="medium"></asp:Label>
                    </td>
                    <td colspan="1" align="right" style="padding-right: 20px;display:none;">
                        <label style="font-size: medium">
                            SubTotal:
                        </label>
                        <asp:Label ID="lblsubttl" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr style="display:none;" border="1">
                   
                    <td colspan="2" align="right" style="padding-right: 20px;display:none;">
                        <label style="font-size: medium;display:none;">
                            CGST:
                        </label>
                        <asp:Label ID="lblcgst" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr style="display:none;" border="1">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label style="font-size: medium">
                            SGST:
                        </label>
                        <asp:Label ID="lblsgst" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>


                 <tr id="iddiscamt" style="" border="1" runat="server" visible="false">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label style="font-size: medium">
                            Discount:
                        </label>
                        <asp:Label ID="lbldiscountamt" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>

                <tr style="font-weight: bold;display:none;" border="1">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label>
                            GrandTotal:-
                        </label>
                        <asp:Label ID="lblGrand" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trCash" runat="server">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label>
                            Cash Received
                        </label>
                        <asp:Label ID="lblReceived" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold; display: none" border="1" id="trPaid" runat="server">
                    <td colspan="2" align="right" style="padding-right: 20px">
                        <label>
                            Balance Paid
                        </label>
                        <asp:Label ID="lblBal" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr style="display:none;">
                    <td colspan="2" align="center">
                        <label style="font-size: large">
                            Kindly Refrigerate Our Fresh Cream products</label><br />
                        <label style="font-size: xx-large">
                           www.blaackforestcakes.com</label><br />
                    </td>
                </tr>
                <tr style="display:none;">
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr style="display:none;">
                   <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For FeedBack/Queries 84899-55500</label></td>
                            </tr>
                             <tr runat="server" visible="false" id="home">
                   <td colspan="2" align="center">
                        <label style="font-size: x-large">
                            For Home Delivery Order 73733 00355</label></td>
                            </tr>
             <tr style="display:none;"><td colspan="2" align="center">
              <label style="font-size: x-large">
                           Book Online Instant Cake Orders 84899-55500 www.Facebook.com/blaackforestcakes</label>
                    </td>
                </tr>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <!-- /.panel -->
        </div>
    </asp:Panel>
    </form>
</body>
</html>
