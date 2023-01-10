<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DayBook.aspx.cs" Inherits="Billing.Accountsbootstrap.DayBook" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >

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
                    <h1 class="page-header">Day Book</h1>
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
                                   
                                        <div class="form-group" id="leg" runat="server"  >
                                     <label>Select Company outlet</label>
                                            <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                             <asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                                              <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                                               <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                                                <asp:ListItem Text="CO4" Value="CO4"></asp:ListItem>
                                                 <asp:ListItem Text="CO5" Value="CO5"></asp:ListItem>
                                            </asp:DropDownList>
                                       
                                     <asp:Button ID="btnfind" runat="server" Text="Find" CssClass="btn btn-success" 
                                                onclick="btnfind_Click" />

                                                 <asp:Button ID="btnall" runat="server" Text="View All" 
                                                CssClass="btn btn-success" onclick="btnall_Click" 
                                                />
                                           
                                        </div>
                                           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <div class="form-group">
                                            <label>From Date </label>
                                            <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server" Text="-----Select Date-----" Width="150px"  ></asp:TextBox>
                                        </div>

                                         
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate" PopupButtonID="txtfromdate" EnabledOnClient="true"  runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>

                                          <div class="form-group">
                                            <label>TO Date </label>
                                            <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="-----Select Date-----" Width="150px"  ></asp:TextBox>
                                        </div>
                                        
                                         
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate" PopupButtonID="txttodate" EnabledOnClient="true" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                           <asp:Button ID="btngen" runat="server" Text="Generate" 
                                            CssClass="btn btn-success" onclick="btngen_Click" 
                                                />   
                                        <asp:Button ID="btnreset" runat="server" Text="Reset" 
                                            CssClass="btn btn-success" onclick="btnreset_Click" 
                                                />
                                          </div>
                                       
                                         
                                       
                                       
                                 
            <!-- /.row -->
        </div>
        <div class="row">
        <asp:GridView ID="gvdaybook"  runat="server" CssClass="myGridStyle" 
                ShowFooter="true" Width="100%" 
                AutoGenerateColumns="false" onrowdatabound="gvdaybook_RowDataBound" 
                 >
            <HeaderStyle BackColor="#3366FF" /><PagerSettings Mode="Numeric" FirstPageText="1" />
            <Columns>
            <asp:BoundField HeaderText="Date" ItemStyle-Width="100px" DataField="Date" />
              <asp:BoundField HeaderText="Description" ItemStyle-Width="600px" DataField="Description" />
               <asp:TemplateField ItemStyle-Width="200px" HeaderText="Debit" ItemStyle-HorizontalAlign="Right" >
        <ItemTemplate >
            <asp:Label ID="lblDebitPrice" runat="server" Text='<%# Eval("Debit","{0:#,0.00}")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lbldebit" runat="server" />
         </FooterTemplate>   
                       
      </asp:TemplateField>
               
                   <asp:TemplateField ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Right" HeaderText="Credit">
        <ItemTemplate>
            <asp:Label ID="lblCreditPrice" runat="server" Text='<%# Eval("credit","{0:#,0.00}")%>' />
         </ItemTemplate>
         <FooterTemplate>
            <asp:Label ID="lblcredit" runat="server" />
         </FooterTemplate>  
         </asp:TemplateField>
                  
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        
   
   <asp:Label ID="lblDebitTotal" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCreditTotal" runat="server" Visible="false"></asp:Label>
  
    <table border="1" >
        <tr>
        <td width="890px" align="right">
         <label>Closing balance</label>
        </td>
        <td width="250px" align="right"><asp:Label ID="lblDebitClosingTotal" runat="server"></asp:Label></td>
        <td width="260px" align="right"> <asp:Label ID="lblCreditClosingTotal" runat="server"></asp:Label></td>
        </tr>
         <tr>
        <td style="padding-top:10px" width="880px" align="right">
         <label>Total</label>
        </td>
        <td width="250px" align="right"><asp:Label ID="lblNetDebit" runat="server"></asp:Label></td>
        <td width="260px" align="right"> <asp:Label ID="lblNetCredit" runat="server"></asp:Label></td>
        </tr>
    </table>
   
    
   
   <br />
    
   
        </div>
        <div class="row">
        <asp:Button ID="btnexcel" runat="server" Text="Export to Excel" 
                CssClass="btn btn-success" onclick="btnexcel_Click" />
       
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
