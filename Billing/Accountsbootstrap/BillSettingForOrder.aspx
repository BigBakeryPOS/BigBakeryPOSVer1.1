<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillSettingForOrder.aspx.cs" Inherits="Billing.Accountsbootstrap.BillSettingForOrder" %>
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
    <title>Bill Paymode Setting For Order Form</title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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

    <script type = "text/javascript">
        var GridId = "<%=gvsales.ClientID %>";
        var ScrollHeight = 300;
        window.onload = function () {
            var grid = document.getElementById(GridId);
            var gridWidth = grid.offsetWidth;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            table.style.cssText = grid.style.cssText;
            table.style.width = gridWidth + "px";
            table.appendChild(document.createElement("tbody"));
            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];
            for (var i = 0; i < cells.length; i++) {
                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }
                cells[i].style.width = parseInt(width - 3) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
            }
            parentDiv.removeChild(grid);

            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
</script>

<script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
     <script type="text/javascript">
         function Search_Gridview(strKey, strGV) {


             var strData = strKey.value.toLowerCase().split(" ");

             var tblData = document.getElementById(strGV);

             var rowData;
             for (var i = 1; i < tblData.rows.length; i++) {
                 rowData = tblData.rows[i].innerHTML;
                 var styleDisplay = 'none';
                 for (var j = 0; j < strData.length; j++) {
                     if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                         styleDisplay = '';
                     else {
                         styleDisplay = 'none';
                         break;
                     }
                 }
                 tblData.rows[i].style.display = styleDisplay;
             }
         } 

    </script>

    <script type="text/javascript">
        function alertMessage() {

            alert('This Bill Not Allow To Cancel.Please Contact Administrator!!!');
        }

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
        }

        
    </script>

   <script type="text/javascript">

       function alertorder() {
           alert('Are You Sure, You want to cancel This Customer sales!');
       }
    </script>
    
</head> 
<body  >
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"   Visible="false">  </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
   <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Order Paymode Setting Details - Order List</h1>
	    </div>

                        <div class="panel-body"  >
                           
                               
                                    <form runat="server" id="form1" method="post">
                                    <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      <asp:ScriptManager ID="script" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
                                       <div class="row"  >
                                    <div class="col-lg-12">
                                    <div class="col-lg-3">
                                    <label>Select Date</label>
                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control center-block"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-3">
                                        <br />
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-secondary" Text="Refresh" OnClick="Search_Click" /> 
                                        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnbillprocess" runat="server" class="btn btn-success pos-btn1" Text="Process Bill's" OnClick="process_Click"   /> 
                                        
                                        </div> 
                                       </div>
                                        </div>
                              <div runat="server" visible="false">
                               <label>Select All</label>
                                <asp:RadioButtonList ID="allradselect" RepeatColumns="2" RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="radselect_All" AutoPostBack="true" >
                                <asp:ListItem Text="Cash" Value="1" ></asp:ListItem>
                                <asp:ListItem Text="Card" Value="4" ></asp:ListItem></asp:RadioButtonList>
                              </div>
                              <br />
                              <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                             
                                        <label>Enter Order/Book No</label>
                                        <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control"  placeholder="Enter Order/Book No and Press Tab"  
                                                 onkeyup="Search_Gridview(this, 'gvsales')" ></asp:TextBox>
                                        
                                <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvsales" align="center"  runat="server" AllowPaging="false" PageSize="25"
                                 AutoGenerateColumns="false" cssClass="table table-striped pos-table"  EmptyDataText="No Records Found" padding="0" spacing="0" border="0" >
                               <%-- <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric"  />--%>
                                <PagerStyle cssclass="pos-paging" />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Payment Type" DataField="type" />
    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
    <asp:BoundField HeaderText="BOOk No" DataField="BookNo" />
    <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}'  />
    <asp:TemplateField Visible="false">
    <ItemTemplate>
    <asp:Label ID="lbltransorderid" runat="server" Text='<%#Eval("transorderid")  %>' style="display:none" ></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="SalesID" DataField="transorderid" Visible="false" />
    
    <asp:BoundField HeaderText="Total Amount" DataField="Amount"  DataFormatString="{0:f}" />
    <asp:BoundField HeaderText="Payment Type" DataField="mod"  DataFormatString="{0:f}" />
    
    <asp:TemplateField HeaderText="PayMode Type" >
    <ItemTemplate>
    <asp:RadioButtonList ID="lblradtype"  RepeatColumns="1" width="100px" runat="server" >
    <asp:ListItem Text="Cash" Value="1" ></asp:ListItem>
    <asp:ListItem Text="Card" Value="4" ></asp:ListItem>
    <asp:ListItem Text="Paytm" Value="10" ></asp:ListItem>
    <asp:ListItem Text="Phonepe" Value="17" ></asp:ListItem>
    </asp:RadioButtonList>
    </ItemTemplate>
    </asp:TemplateField>
   </Columns>
   
 <%--<FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />--%>
   </asp:GridView>
                                    </div>
                                    </div>
                                    <div class="col-lg-4">
                                 <br /><br />
                                 <label>Cash Bill's</label>
                                 <div class="table-responsive panel-grid-left">
                                  <asp:GridView ID="gridcash" align="center"  runat="server" AllowPaging="false" PageSize="25"
                                 AutoGenerateColumns="false" cssClass="table table-striped pos-table"  EmptyDataText="No Records Found" padding="0" spacing="0" border="0"  >
                               <%--  <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric"  />--%>
                                <PagerStyle cssclass="pos-paging" />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
   <asp:BoundField HeaderText="Payment Type" DataField="type" />
    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
    <asp:BoundField HeaderText="BOOk No" DataField="BookNo" />
    <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}' />
    
    <asp:BoundField HeaderText="Total Amount" DataField="Amount"  DataFormatString="{0:f}" />
    <asp:BoundField HeaderText="Paymode Type" DataField="mod"  DataFormatString="{0:f}" />
    </Columns>
 <FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   </asp:GridView>
                                 </div>
                                 </div>
                                 <div class="col-lg-4">
                                 <br /><br />
                                 <label>Card Bill's</label>
                                 <div class="table-responsive panel-grid-left">
                                  <asp:GridView ID="gridcard" align="center"  runat="server" AllowPaging="false" PageSize="25" padding="0" spacing="0" border="0"
                                 AutoGenerateColumns="false" cssClass="table table-striped pos-table"  EmptyDataText="No Records Found"  >
                                 <%--<HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric"  />--%>
                                <PagerStyle cssclass="pos-paging" />
    <Columns>
   <asp:BoundField HeaderText="Payment Type" DataField="type" />
    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
    <asp:BoundField HeaderText="BOOk No" DataField="BookNo" />
    <asp:BoundField HeaderText="Bill Date" DataField="Billdate" DataFormatString='{0:d}' />
    
    <asp:BoundField HeaderText="Total Amount" DataField="Amount"  DataFormatString="{0:f}" />
    <asp:BoundField HeaderText="Paymode Type" DataField="mod"  DataFormatString="{0:f}" />
    </Columns>
 <FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   </asp:GridView>
                                    </div>
                                 </div>
                                </div>
                                </div>
                                </div>   
                                </div>



                                     </ContentTemplate>
                                    </asp:UpdatePanel>


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
         <asp:TextBox ID="txtRef" runat="server"  placeholder="Enter Reference BillNo" ></asp:TextBox>
            <p>
           
                Are you sure want to Cancel this Bill?
            </p>
        </div>
        <div align="center" class="popup_Buttons">
            <input id="ButtonDeleleOkay" type="button" value="Yes" />
            <input id="ButtonDeleteCancel" type="button" value="No" />
        </div>
    </div>
</asp:panel> 
                                   
                                    </form>
                        </div>
                      
</div>
</div>
</div>
</div>

</body>

</html>


