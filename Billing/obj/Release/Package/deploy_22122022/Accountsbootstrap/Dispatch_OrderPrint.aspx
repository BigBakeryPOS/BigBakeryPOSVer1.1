<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dispatch_OrderPrint.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Dispatch_OrderPrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
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
    <script type="text/javascript">
        window.print();
    </script>
    <style type="text/css">
        @media print
        {
            body
            {
                background-color: #FFFFFF;
                background-image: none;
                color: #000000;
            }
            #ad
            {
                display: none;
            }
            #leftbar
            {
                display: none;
            }
            #contentarea
            {
                width: 100%;
            }
        }
    </style>
</head>
<body onload="window.print()">
    <form id="Form1" runat="server" role="form">
    <asp:Panel ID="pnlContents" runat="server">
        <!-- /.row -->
        <div align="center">
            <table width="500px" style="font-size: x-large; font-family: Calibri; font-weight: bold">
                <tr>
                    <td colspan="2" align="center" style="font-size: x-large;">
                        <br />
                        <img width="200px" height="121px" src="../images/BlackForrest.png" />
                        <br />
                        <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: x-large;"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Dispatch No:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lbldispatchno" runat="server"></asp:Label>
                    </td>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Dispatch Date:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lbldispatchdate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Vehicle No:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lblvehicelno" runat="server"></asp:Label>
                    </td>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Employee Name:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lblempname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding-left: 5px">
                        <div id="PRINTIDRec" runat="server">
                            <asp:GridView ID="Griddc" runat="server" AutoGenerateColumns="false" Font-Names="Calibri"
                                OnRowCreated="Griddc_RowCreated" OnRowDataBound="Griddc_RowDataBound" Font-Size="15px">
                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="Book No" DataField="bookno" />
                                    <asp:BoundField HeaderText="Ord.Date" DataField="orderdate" />
                                    <asp:BoundField HeaderText="Delv.Date" DataField="Deliverydate" DataFormatString='{0:d}' />
                                    <asp:BoundField HeaderText="Delv.Time" DataField="deliverytime" />
                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                                    <asp:BoundField HeaderText="Sent Qty" DataField="Oqty" />
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                            <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <br />
                        <br />
                        <label style="font-size: large">
                            Check Out Signature</label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="display: none">
                        <label style="font-size: small">
                            For any FeedBack/Queries Kindly Call 8489955500 www.Facebook.com/blaackforestcakes</label>
                    </td>
                </tr>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <!-- /.panel -->
        </div>
    </asp:Panel>
    </form>
</body>
</html>
