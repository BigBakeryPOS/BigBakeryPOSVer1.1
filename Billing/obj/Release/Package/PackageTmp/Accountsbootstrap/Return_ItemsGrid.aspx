<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Return_ItemsGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.Return_ItemsGrid" EnableEventValidation="false" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  >
    
 <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Home</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>
    <script src="js/jquery.table2csv.0.1.1.min.js" type="text/javascript"></script>
    <!-- Custom Fonts -->
    
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <style type="text/css" xml:space="preserve" class="blink"> text-decoration: blink; </style>
    <style type="text/css">
    .blinkytext
    {
     text-decoration: blink;
    }
</style>
<script type="text/javascript">
    function printGrid() {
        var gridData = document.getElementById('<%= grid.ClientID %>');
        var windowUrl = 'about:blank';
        //set print document name for gridview
        var uniqueName = new Date();
        var windowName = 'Print_' + uniqueName.getTime();

        var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
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
    
    <script type="text/javascript" language="javascript">
        function exportToExcel() {
            var oExcel = new ActiveXObject("Excel.Application");
            var oBook = oExcel.Workbooks.Add;
            var oSheet = oBook.Worksheets(1);
            for (var y = 0; y < GridView3.rows.length; y++)
            // GridView3 is the table where the content to be exported is
            {
                for (var x = 0; x < GridView3.rows(y).cells.length; x++) {
                    oSheet.Cells(y + 1, x + 1) =
GridView3.rows(y).cells(x).innerText;
                }
            }
            oExcel.Visible = true;
            oExcel.UserControl = true;
        }
    
    </script>
    
     
</head>
<body >
  <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
     <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
               
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


          <div class="row" >
                <div class="col-lg-12" >
                    <div class="panel panel-default" >
                        
                        <div class="panel-body" >
                            <div class="row">
    <div >
    <h2><label>Return Form Store</label></h2>
    </div>
    
    
    <div>
   
    </div>
    <div class="col-lg-12">
    <div class="col-lg-2">
      <label >
                                        From date</label>
                                
                                 
                                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" Width="150px">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
    </div>
    <div class="col-lg-2">
     <label >
                                        To date</label>
                                    <asp:TextBox runat="server" ID="txttodate" CssClass="form-control"  Width="150px">
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
    </div>
    <div class="col-lg-2">
     <label CssClass="form-control">Reasons</label>
                                        <asp:DropDownList ID="drpPayment" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="drpPayment_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Select Reasons" Value="0" ></asp:ListItem>
<%-- <asp:ListItem Text="Wastage" Value="1" Enabled="false" ></asp:ListItem>--%>
 <asp:ListItem Text="DateBar" Value="2" ></asp:ListItem>
<%-- <asp:ListItem Text="Excess" Value="3" ></asp:ListItem>--%>
  <asp:ListItem Text="Damage" Value="4" ></asp:ListItem>
  <asp:ListItem Text="Wrong GRN" Value="5" ></asp:ListItem>
  <%--<asp:ListItem Text="Shortage" Value="6" ></asp:ListItem>
  <asp:ListItem Text="Fungus" Value="7" ></asp:ListItem>
  <asp:ListItem Text="Fungus Before Date" Value="8" ></asp:ListItem>
  <asp:ListItem Text="To Production" Value="9" ></asp:ListItem>
   <asp:ListItem Text="Return To Production(Recycle)" Value="10" ></asp:ListItem>
   <asp:ListItem Text="Staff Consumed" Value="11" ></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="12" ></asp:ListItem>--%>
     <asp:ListItem Text="Stock (+)(-)" Value="13" ></asp:ListItem>
     <asp:ListItem Text="Stock Shift" Value="14" ></asp:ListItem>
     <asp:ListItem Text="Stock Consumed" Value="15" ></asp:ListItem>
 
 </asp:DropDownList>
    </div>

    <div class="col-lg-2">
                                 <div class="form-group">
                                 <label>Sub Reasons</label>
                                        <asp:DropDownList ID="ddlsubreasons" runat="server" CssClass="form-control" Width="200px">

 
 </asp:DropDownList>
 </div>
                               </div>
    <div class="col-lg-2">
    <div class="form-group" id="Production" runat="server">
    <label class="form-control-label">select Store</label>
      <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" Width="200px">
    
      <asp:ListItem Text="KK Nagar" Value="co1" ></asp:ListItem>
       <asp:ListItem Text="Byepass" Value="co2"></asp:ListItem>
      
      
    </asp:DropDownList>
    </div>
    <div class="form-group" id="Production2" runat="server">
    <label class="form-control-label">select Store</label>
      <asp:DropDownList ID="ddbr" runat="server" CssClass="form-control" Width="200px">
           <asp:ListItem Text="BB Kulam" Value="co3"></asp:ListItem>
         <asp:ListItem Text="NarayanaPuram" Value="co4"></asp:ListItem>
      
    </asp:DropDownList>
    </div>
    <div class="form-group" id="ProductionNellai" runat="server">
    <label class="form-control-label">select Store</label>
      <asp:DropDownList ID="ddnellai" runat="server" CssClass="form-control" Width="200px">
           <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
         
      
    </asp:DropDownList>
    </div>
    <div class="form-group" id="ProductionChennai" runat="server">
    <label class="form-control-label">select Store</label>
      <asp:DropDownList ID="dChennai" runat="server" CssClass="form-control" Width="200px">
           <asp:ListItem Text="Maduravayol" Value="co6"></asp:ListItem>
           <asp:ListItem Text="Purasaivakkam" Value="co7"></asp:ListItem>
         
      
    </asp:DropDownList>
    </div>
    </div>
    <div class="col-lg-2">
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
          CssClass="btn btn-success" onclick="btnSearch_Click" />
    </div>
   
                                  
    
     
    
    
    </div>
     <div class="col-lg-12">
     <div>
     <label>Total</label>
                                         <label id="lblTotal" runat="server"></label>
     </div>
     <div>
     <asp:Button  ID="btnPrint" runat="server" CssClass="btn btn-success" Text="Print" 
                                                onclick="btnPrint_Click" />

                                                <asp:Button  ID="btnExport" 
             runat="server" CssClass="btn btn-success"  
                                                Text="Export To Excel" onclick="btnExport_Click2"  
             />
     </div>
     </div>
     <div class="form-group" id="content" runat="server"> 
     <table cellpadding="10" cellspacing="10" style="font-family: Arial; font-size: 12px;
            border: solid 1px #ccc;" border="1" align="center">
            <tr>
            <td>
             <label class="form-control-label"> Returned Items List</label>
                   <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" Font-Size="Large" >
                   <Columns>
                    <asp:BoundField HeaderText="From Store" DataField="Store" ItemStyle-Width="20px" Visible="false"  />
                                                                                            
                                                    <asp:BoundField HeaderText="Return No" DataField="RetNo" ItemStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="50px"  />
                                                 <asp:BoundField HeaderText="Date" DataField="ReturnDate" DataFormatString="{0:MM/dd/yy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                                                   <asp:BoundField HeaderText="Group" DataField="Category" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                                                   <asp:BoundField HeaderText="Item" DataField="Definition" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                                                     <asp:BoundField HeaderText="Qty" DataField="Quantity" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                                                     <asp:BoundField HeaderText="Amt" DataField="Amount" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                                                       <asp:BoundField HeaderText="Reason" DataField="Reason" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" />
                   </Columns>
                   </asp:GridView> 
            </td>
            </tr>
            </table>
                           
     </div>
     
    </div>
    </div>
    </div>
    </div>
    </div>
   
    </form>
</body>
</html>
