<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchasePrint.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PurchasePrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
    <script language="javascript" type="text/javascript">
        window.print();
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
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server" role="form">
    <asp:Panel ID="pnlContents" runat="server">
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label>
                                                    Address</label><br />
                                                <asp:Label ID="lblcustname" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblarea" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblcity" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblpin" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblph" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblMail" runat="server"></asp:Label>
                                                <div class="form-group" style="margin-top: -145px">
                                                    <label style="margin-left: 470px">
                                                        DC NO&nbsp&nbsp&nbsp&nbsp:</label>
                                                    <asp:Label ID="lblDc_No" runat="server"></asp:Label><br />
                                                </div>
                                                <div class="form-group">
                                                    <label style="margin-left: 470px">
                                                        DC Date&nbsp:</label>
                                                    <asp:Label ID="lblDc_Date" runat="server"></asp:Label><br />
                                                </div>
                                                <div class="form-group">
                                                    <label style="margin-left: 470px">
                                                        Bill No&nbsp&nbsp&nbsp:</label>
                                                    <asp:Label ID="lblbillno" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </div>
                            </div>
                            <!-- /.row -->
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-default">
                                        <!-- /.panel-heading -->
                                        <div class="panel-body">
                                            <div class="table-responsive">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="BankGrid" runat="server" CssClass="mGrid" Width="100%" AllowSorting="true"
                                                                EmptyDataText="No Records Found" AutoGenerateColumns="false">
                                                                <HeaderStyle BackColor="#3366FF" />
                                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                    NextPageText="Next" PreviousPageText="Previous" />
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="IngredientName" DataField="IngredientName" />
                                                                    <asp:BoundField HeaderText="Units" DataField="UOM" />
                                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                                                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                                </Columns>
                                                                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <!-- /.table-responsive -->
                                            <!-- /.col-lg-6 (nested) -->
                                        </div>
                                        </form>
                                        <!-- /.row (nested) -->
                                    </div>
                                    <!-- /.panel-body -->
                                </div>
                                <!-- /.panel -->
                            </div>
                            <!-- /.col-lg-12 -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /#page-wrapper -->
                </div>
            </div>
            </div> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
