<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LedgerReport.aspx.cs" Inherits="Billing.Accountsbootstrap.LedgerReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title> </title>
    

   <link rel="Stylesheet" type="text/css" href="../Styles/date.css" />
   
   <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    
	<%--<script type="text/javascript" src="../jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar.css"/>--%>

    <!-- Bootstrap Core CSS -->
    <link href="../Styles/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../Styles/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />



</head>
<body>

  <usc:Header ID="Header" runat="server" />  
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                   <form id="Form1" runat="server">
                      
                                 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Ledger Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
        <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                   
                                        <div class="form-group">
                                     <label>Ledger Name</label>
                                            <asp:DropDownList ID="ddLedger" runat="server" CssClass="form-control"></asp:DropDownList>
                                       
                                     <asp:Button ID="btnfind" runat="server" Text="Find" CssClass="btn btn-success" 
                                                onclick="btnfind_Click" />
                                           
                                        </div>
                                               <div class="form-group" id="from" runat="server">
                                            <label>From Date</label>
											<asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="--Select Date--"></asp:TextBox>
                                                                                       
                                        </div>
                                        <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate"  runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
										<div class="form-group" id="to" runat="server">
                                            <label>To Date</label>
											<asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="--Select Date--"></asp:TextBox>
                                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                                <asp:Button ID="btnSearch" runat="server" Text="Search"  
                                                CssClass="btn btn-success" onclick="btnSearch_Click" />                                       
                                        </div>
                                        
                                        </div>
         
                                        
                                          </div>
                                       
                                         
                                       
                                       
                                 
            <!-- /.row -->
        </div>
       <div  class="row" style="margin-left:10px"> <asp:RadioButton ID="rbBranch1" runat="server" Text="Branch1" 
               GroupName="Branch" oncheckedchanged="rbBranch1_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="rbBranch2" runat="server" Text="Branch2" GroupName="Branch" 
               oncheckedchanged="rbBranch2_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="rbBranch3" runat="server" Text="Branch3" GroupName="Branch" 
               oncheckedchanged="rbBranch3_CheckedChanged" AutoPostBack="true"/>
        <asp:RadioButton ID="rbAll" runat="server" Text="All" GroupName="Branch" 
               oncheckedchanged="rbBranch4_CheckedChanged" AutoPostBack="true" /></div>
        <div class="row" style="margin-left:10px" >
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gvdaybook"  runat="server" CssClass="myGridStyle" ShowFooter="true" Width="100%" 
                AutoGenerateColumns="false" onrowdatabound="gvdaybook_RowDataBound" >
            <HeaderStyle BackColor="#3366FF" />
            <Columns>
            <asp:BoundField HeaderText="Date" DataField="Date" />
              <asp:BoundField HeaderText="Description" DataField="Description" />
               <asp:TemplateField HeaderText="Debit" >
        <ItemTemplate >
            <asp:Label ID="lblDebitPrice" runat="server" Text='<%# Eval("Debit","{0:#,0.00}")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lbldebit" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>
               
                   <asp:TemplateField HeaderText="Credit">
        <ItemTemplate>
            <asp:Label ID="lblCreditPrice" runat="server" Text='<%# Eval("credit","{0:#,0.00}")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblcredit" runat="server" />
         </FooterTemplate>                   
      </asp:TemplateField>
                   <asp:BoundField HeaderText="Outlet Name" DataField="Company" />
                    <asp:BoundField HeaderText="Ledger  Name" DataField="LedgerName" />
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        </asp:GridView>
         <br />
   
   <asp:Label ID="lblDebitTotal" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCreditTotal" runat="server" Visible="false"></asp:Label>
    <br />
    
    <asp:Label ID="lblDebitClosingTotal" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCreditClosingTotal" runat="server" Visible="false"></asp:Label>
   <br />
    
    <asp:Label ID="lblNetDebit" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblNetCredit" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="row">
        
       
        </div>
        <!-- /#page-wrapper -->
		</div>
        </div>
        </div>
        </div>
        </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
