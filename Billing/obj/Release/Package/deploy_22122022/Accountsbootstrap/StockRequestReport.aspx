<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockRequestReport.aspx.cs" Inherits="Billing.Accountsbootstrap.StockRequestReport" %>
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

    <title>Stock Inward Report</title>
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
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="scrip" runat="server"></asp:ScriptManager>
    
 
          <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <asp:Label ID="lblstockid"  runat="server" Visible="false"></asp:Label>
 
 
            <div class="row" align="center">
                <div class="col-lg-12">
                    <h1 class="page-header">Stock Inward Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                          
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <div class="row">
                            <div class="panel-body">
                            <div class="col-lg-3">
    <label>Select Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Visible="false"  Width="150px" 
                                       >
                                       <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                                       <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                                       <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                                       <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                                       <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                       <asp:ListItem Text="Maduravayol" Value="co6"></asp:ListItem>
                                       <asp:ListItem Text="Purasavakkam" Value="co7"></asp:ListItem>
                                    </asp:DropDownList>
    </div>
                            <div class="form-group">
                            <label>From Date</label>
                            <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cal"  runat="server" TargetControlID="txtfromdate" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="form-group">
                            <label>To Date</label>
                             <asp:TextBox ID="txttoDate" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txttoDate" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                            </div>
                             <div class="form-group">
                             <asp:Button ID="btnser" runat="server" Text="Search" CssClass="btn-danger" 
                                     onclick="btnser_Click" />
                                     <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn-success" 
                                     onclick="btnexport_Click" />
                             </div>
                            </div>
                            </div>
                             <div class="row">
                             <asp:GridView ID="gv" runat="server" CssClass="mGrid" Width="500px" EmptyDataText="No Datas Found">
                             </asp:GridView>

                              
                             </div>
                            
                            </ContentTemplate>
    
   </asp:UpdatePanel>
                              
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
       </form>

</body>

</html>
