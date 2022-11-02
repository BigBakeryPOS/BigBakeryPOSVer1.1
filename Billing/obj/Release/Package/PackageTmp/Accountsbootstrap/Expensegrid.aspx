<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expensegrid.aspx.cs" Inherits="Billing.Accountsbootstrap.Expensegrid" EnableEventValidation = "false" ValidateRequest="false" %>
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
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gridledger.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="size:landscape">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
</script>

    <title>Expense Grid</title>
     <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
       <link rel="Stylesheet" type="text/css" href="../css/date.css" />

 <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	<script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css"/>
   
   
   <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    



    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />

      <script type="text/javascript">

          function alertorder() {
              alert('Are You Sure, You want to cancel This Customer sales!');
          }
    </script>

</head>
<body>
            <form runat="server" id="form1" method="post">
   <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Payment Details</b></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                  
                                     <asp:scriptmanager id="ScriptManager1" runat="server">
                                              </asp:scriptmanager>
                                    <div class="form-group">
                                         
                                           
                                            <asp:DropDownList ID="ddlsearch" CssClass="form-control"  Visible="false"
                                                runat="server" Width="237px"> 
                                                </asp:DropDownList><br />
                                              <label>From :</label>
                                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"  Text="--Select Date--"
                                                Width="237px" ></asp:TextBox>
                                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFrom" runat="server"  
                                        CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                       
                                                 <label>To :</label>
                                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Text="--Select Date--" 
                                                Width="237px" ></asp:TextBox>
                                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtTo" runat="server"
                                        CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                              
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" 
                                                style="margin-top: 10px;" onclick="btnsearch_Click"  /> 
                                         
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-primary" Text="Add" 
                                                style="margin-top: 10px;" onclick="btnadd_Click" />  

                                                 <asp:Button ID="btnPrint" runat="server" class="btn btn-success" Visible="false" Text="Print" 
                                                style="margin-top: 10px;" OnClientClick=" printGrid();" />  

                                                 <asp:Button ID="btnexportexcel" runat="server" class="btn  btn-warning" Text="Export-Excel"  OnClick="btnExport_Click"
                                                style="margin-top: 10px;"  />  
                                        </div> 
                               </div>

                               <div class="col-lg-12">

                               <div runat="server" id="div1" class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>

                                 <div runat="server" id="div2" class="table-responsive">
                                
                                <asp:GridView ID="gridledger" runat="server" AllowPaging ="false"  PageSize="50"   
                                        AutoGenerateColumns="false" CssClass="mGrid" 
                                        onrowcommand="gridledger_RowCommand">
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="1"  Mode="Numeric"  />
                                <Columns>
                                
                                <asp:BoundField HeaderText="Payment Entry ID" DataField="PaymentEntryID"  />
                                <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString='{0:dd-MMM-yyyy}'   />
                                <asp:BoundField HeaderText="Ledger Name" DataField="LedgerName" />
                                <asp:BoundField HeaderText="Description" DataField="Description" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:###,##0.00}" />
                                <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                <asp:LinkButton ID="lnkbtn" runat="server" CommandName="Del" CommandArgument='<%#Eval("PaymentEntryID") %>'><asp:Image ID="imgdel" runat="server" ImageUrl="~/images/delete.png" /></asp:LinkButton>
                                <%-- <ajaxToolkit:modalpopupextender   
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="lnkbtn"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="lnkbtn" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>--%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                          <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                 </asp:GridView>
                                 </div>
                                </td>
                                </tr>
                                <tr>
                                            <td>
                                            Total: <label id="lblTotal" runat="server"></label>
                                            </td>
                                            </tr>
                                </table>
                                </div>


                                <asp:panel Width="30%" class="popupConfirmation" id="DivDeleteConfirmation" 
	style="display: none; background:#fffbd6"  runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div align="center"  style="color:Red" class="TitlebarLeft">
                Warning Message!!!</div>
            <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div  align="center" style="color:Red" class="popup_Body">
            <p>
                Are you sure want Delete this ?
            </p>
        </div>
        <div align="center" class="popup_Buttons">
            <input id="ButtonDeleleOkay" type="button" value="Yes" />
            <input id="ButtonDeleteCancel" type="button" value="No" />
        </div>
    </div>
</asp:panel>
                                     
                                   
                                
                                </div>
                                
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

                </form>
</body>
</html>
