<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterGoodsTransferReport.aspx.cs" Inherits="Billing.Accountsbootstrap.InterGoodsTransferReport" %>

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
    <title>Goods Transfer Grid </title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= grid.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=100,height=100');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head> 
<body style="">
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
   
           <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Goods Transfer Details</h1>
	    </div>
        
                        <div class="panel-body">
                        
                                    <form runat="server" id="form1" method="post"> 
                                    
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <div class="row">
                                    <div class="col-lg-3">
                                            <label>Filter By</label>
                                            <asp:DropDownList ID="ddlBranch" CssClass="form-control"  
                                                runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                         </div>
                                         
                                       <div class="col-lg-3">  
                                       
                                         <label class="form-control-label">From Date</label>
                                        <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox>
                                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtDate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">  
                                          
                                         <label class="form-control-label">To Date</label>
                                        <asp:TextBox ID="txtToDate" runat="server" class="form-control"></asp:TextBox>
                                         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                         
                                         </div>
                                          <div class="col-lg-3">                                                     
                                           <br />
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-primary pos-btn1" Text="Search"  
                                                 onclick="btnsearch_Click"   /> 
                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" Text="Reset"  
                                                /> 
                                       
                                        </div> 
                                       </div>
                                        
                                        
                               <div class="row">
                               <div class="col-lg-6">
                               <div class="table-responsive panel-grid-left">
                           
                                <asp:GridView ID="gvGoodTransFer" runat="server" AllowPaging="true" PageSize="5"   padding="0" spacing="0" border="0"
                                        AutoGenerateColumns="false" cssClass="table table-striped pos-table" onrowcommand="gvGoodTransFer_RowCommand" >
                                 <PagerStyle CssClass="pos-paging" />
                                <%--<PagerSettings  Mode="Numeric"  />--%>
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
   <asp:BoundField HeaderText="DC NO" DataField="DC_NO" />
     <asp:BoundField HeaderText="DC Date" DataField="Dc_Date" />
     <asp:BoundField HeaderText="Production Request No" DataField="requestNo" />
     <asp:BoundField HeaderText="Branch Request No" DataField="BranchReqNo" />
    <asp:BoundField HeaderText="From Branch" DataField="FromBranchCode" />

    <asp:BoundField HeaderText="To Branch" DataField="ToBranchCode" />
    <asp:BoundField HeaderText="Transfer By" DataField="SentBy" />
     <asp:TemplateField HeaderText="Transfer">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("Dc_No") %>' CommandName="Transfer" OnClientClick="alertMessage()">
           <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/transfer.jpg" Width="30px" Height="30px" visible="false" />
            <button type="button" class="btn btn-danger btn-md">
				<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
			</button>
           </asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>

       <asp:TemplateField HeaderText="View Detail" Visible="false" >
     <ItemTemplate>
           <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("Dc_No") %>' CommandName="view" >
           <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" visible="false"/>
            <button type="button" class="btn btn-default btn-md">
				<span class="glyphicon glyphicon-print" aria-hidden="true"></span>
			</button>
           </asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>

     
   </Columns>
    <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
   </asp:GridView>
                         
                                <asp:GridView ID="gvDetails" runat="server" cssClass="table table-striped pos-table" AutoGenerateColumns="false" padding="0" spacing="0" border="0">

                                <Columns>
                                <asp:BoundField HeaderText="Item" DataField="Category" />
     <asp:BoundField HeaderText="Category" DataField="Definition" />
     <asp:BoundField HeaderText="Qty" DataField="Qty" />
          <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" />
    

                                </Columns>
                                             <%--<FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />  --%>             
                                </asp:GridView>
                                </div>
                                </div>
                                <div class="col-lg-6">
                               <div class="table-responsive panel-grid-left">
                                <label>Goods Transfer Details</label>
                                
                                <asp:GridView ID="gvTransfer" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="false" 
                                        cssClass="table table-striped pos-table" onrowcommand="gvTransfer_RowCommand" padding="0" spacing="0" border="0">
                                <Columns>
                                 <asp:BoundField HeaderText="DC No" DataField="DC_NO" />
     <asp:BoundField HeaderText="DC_Date" DataField="DC_Date" />
     <asp:BoundField HeaderText="From Branch" DataField="FromBranchCode" />

    <asp:BoundField HeaderText="Transfer To Branch" DataField="ToBranchCode" />
          <asp:BoundField HeaderText="Branch Req.No" DataField="BranchReqNO" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:TemplateField HeaderText ="Export">
            
            <ItemTemplate>
            <asp:LinkButton ID="btnexp" runat="server" CommandName="Exp" CommandArgument='<%#Eval("DC_NO")+";"+Eval("Branch")+";"+Eval("DC_Date") %>'>
            <asp:Image ID="imgexp" runat="server" ImageUrl="~/images/xcel.png"  Width="50px" Height="50px" Visible="false" />
            <button type="button" class="btn btn-success btn-md">
						                                    <span class="glyphicon glyphicon-export" aria-hidden="true"></span>
					                                    </button>
            </asp:LinkButton>
            
            </ItemTemplate>
             
            </asp:TemplateField>
               <asp:TemplateField HeaderText ="Print">
                <ItemTemplate>
            <asp:LinkButton ID="btnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("DC_NO")+";"+Eval("Branch")+";"+Eval("DC_Date") %>'>
            <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png"  Width="50px" Height="50px" Visible="false"/>
            <button type="button" class="btn btn-default btn-md">
						                                <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                </button>
                                                    </asp:LinkButton>
            
            </ItemTemplate>
               </asp:TemplateField>

                                 <asp:TemplateField HeaderText ="View">
                <ItemTemplate>
            <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%#Eval("DC_NO")+";"+Eval("Branch")+";"+Eval("DC_Date") %>'>
            <asp:Image ID="imgprint1" runat="server" ImageUrl="~/images/info_button.png"  Width="50px" Height="50px" Visible="false"/>
            <button type="button" class="btn btn-primary btn-md">
						                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                </button>
            </asp:LinkButton>
            
            </ItemTemplate>
               </asp:TemplateField>

                                </Columns>
                                
  <%--<FooterStyle BackColor="#990100"  ForeColor="White" HorizontalAlign="Center" />--%>
  <%-- <HeaderStyle BackColor="#428bca"  ForeColor="White" HorizontalAlign="Center" />--%>   
                                </asp:GridView>
                                
                                <asp:GridView ID="grid" runat="server" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"></asp:GridView>
                                </div>
                                </div>
                              </div>
                                    </form>
                             
                        </div>
                        </div>
                      
    </div>
    </div>
    </div>
    

</body>

</html>

