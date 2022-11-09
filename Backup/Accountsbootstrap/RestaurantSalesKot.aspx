<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantSalesKot.aspx.cs" Inherits="Billing.Accountsbootstrap.RestaurantSalesKot" %>

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
    <title>Restaurant Kot Grid </title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
   <!-- Bootstrap Core CSS -->
   <%-- <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>--%>

    <!-- MetisMenu CSS -->
    <%--<link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />--%>
    <!-- Custom CSS -->
  <%--  <link href="../css/sb-admin-2.css" rel="stylesheet"/>--%>

    <!-- Custom Fonts -->
    

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    
    <![endif]-->
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

      <%--<style type="text/css">
        .button {
    background-color: #785a39;
    border: 1px;
    color: white;
    padding: 1px 3px;
    width:150px;
    height:50px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 12px;
       cursor: pointer;
    border-radius: 25px;
}

.labelTxt {
    color:Black;
    border: 1px;
   
    padding: 1px 3px;
    width:150px;
    height:20px;
    text-align: right;
    text-decoration: none;
    display: inline-block;
    font-family:Calibri;
    font-size: 12px;
       cursor: pointer;
  
}


.button1 {
    background-color: #9e6d32;
    border: none;
    color: white;
    padding: 1px 10px;
    height:50px;
    font-weight:bold;
    width:125px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 12px;
    margin: 4px 2px;
    cursor: pointer;
}

    
  .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;
    }
    .modalPopup
    {
        background-color: #b4dbec;
        width: 800px;
        height:600px;
        border: 3px solid #0DA9D0;
        border-radius: 12px;
        padding:0
      
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .footer
    {
        padding: 6px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        border-radius: 4px;
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
    
    
    
    
</style>--%>

   <script type="text/javascript">

       function alertorder() {
           alert('Are You Sure, You want to cancel This Customer sales!');
       }
    </script>
     <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
    
</head> 
<body>
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"   Visible="false">  </asp:Label>
             <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  Visible="false"> </asp:Label>
             <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
   <div class="clearfix"></div>
   <div class="container-fluid">
       <div class="row panel panel-custom1">
        <div class="panel-heading">
            <h3 class="panel-title">Table Details</h3>
        </div>
        <div class="panel-body panel-full-scroll">
            <div class="row">
                <div class="col-lg-12 text-center"  >
                                               
                                    <form runat="server" id="form1" method="post">
                                     <asp:Button ID="btnclear" runat="server" Text="Print Clear" OnClick="btlprintClear"  class="btn btn-md btn-success"   />
                <div class="row">
                    <div class="col-md-12" style="padding: 20px 0;">
                    <label>Billing Type: </label>
                    <asp:RadioButtonList ID="radtypestatus" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                    <asp:ListItem Text="Billing" Value="1" Selected="True" ></asp:ListItem>
                    <asp:ListItem Text="Cancel" Value="2" ></asp:ListItem></asp:RadioButtonList>
                    </div>
                </div>
                                    <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      <asp:ScriptManager ID="script" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
                                    <div class="form-group" style="display:none"  >

                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" OnClick="Search_Click" style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" OnClick="refresh_Click" style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Visible="false" Text="Add" OnClick="Add_Click" style="margin-top: 10px;" />  
                                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Add" PostBackUrl="~/Accountsbootstrap/NewButtonRandDaspx.aspx" style="margin-top: 10px;" Visible="false" />  
                                        </div> 
                                        <div class="form-group" style="display:none" >
                                        <label>Enter Billno to Cancel</label>
                                        <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" Width="200px" placeholder="Enter Billno and Press Tab"  AutoPostBack="true"  
                                                ontextchanged="txtAutoName_TextChanged" ></asp:TextBox>
                                                
                                        </div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-12">
                                        <div style="background-color:#ffffff" align="center">
                                    <asp:DataList ID="datkot" runat="server" CssClass="table"   ScrollBars="auto"  
                                        RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Table" Width="100%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="Button2" Font-Bold="true" style="white-space: normal" runat="server"
                                                Width="100px" Text='<%#Eval("Tablename")%>' CommandName='<%#Eval("Tablename")%>' CssClass="btn btn-lg pos-btn1"
                                                CommandArgument='<%#Eval("TableId") %>  '  OnClick="Button2_Click" />
                                                
                                        </ItemTemplate> 
                                    </asp:DataList>
                                </div>
                                        </div>
                                        <div class="col-lg-6">
                                        <div class="table-responsive" align="center" >
                            

                                
                                <asp:GridView ID="gvsales" align="center"  runat="server" AllowPaging="true" PageSize="25" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnPageIndexChanging="Page_Change" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" onrowcommand="gvsales_RowCommand" EmptyDataText="No Records Found"  >
                             
                                <PagerSettings FirstPageText="1" Mode="Numeric"  />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
    <asp:BoundField HeaderText="SalesID" DataField="SalesID" Visible="false" />
    <asp:BoundField HeaderText="Contact Name" DataField="CustomerName" />
     <asp:BoundField HeaderText="Contact Type" DataField="ContactType" Visible="false" />
    <asp:BoundField HeaderText="Area" DataField="Area" Visible="false" />
    <asp:BoundField HeaderText="City" DataField="City" Visible="false"/>
    <asp:BoundField HeaderText="Net Amount" DataField="NetAmount"  DataFormatString="{0:f}" />
     <asp:TemplateField HeaderText="Edit" Visible="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="edit"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
     <asp:TemplateField HeaderText="Cancel Sales">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>' CommandName="cancel" ><asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png" /></asp:LinkButton>

            <ajaxToolkit:modalpopupextender
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="btndelete"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btndelete" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>

   </ItemTemplate>
    
     
     
     </asp:TemplateField>

      <asp:TemplateField Visible="false" HeaderText="View Details">
     <ItemTemplate>
           <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("SalesID") %>' CommandName="view" ><asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>

       <asp:TemplateField HeaderText="Print">
     <ItemTemplate>
           <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="print" ><asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>
   </Columns>
   

   </asp:GridView>
                            
                                  <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="10" CssClass="mydatagrid" PagerStyle-CssClass="pager"             HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                        DataKeyNames="BillNo" ShowFooter="true" OnPageIndexChanging="Page_Change" OnRowDataBound="gvCustsales_RowDataBound"
                                                        AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%" HeaderText="BillNo."
                                                                HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript:switchViews('dv<%# Eval("BillNo") %>', 'imdiv<%# Eval("BillNo") %>');"
                                                                        style="text-decoration: none;">
                                                                        <img id="imdiv<%# Eval("BillNo") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                                    </a>
                                                                    <%# Eval("BillNo") %>
                                                                    <div id="dv<%# Eval("BillNo") %>" style="display: none; position: relative;">
                                                                        <asp:GridView runat="server" ID="gvLiaLedger" CssClass="mydatagrid" PagerStyle-CssClass="pager"             HeaderStyle-CssClass="header" RowStyle-CssClass="rows" GridLines="Both"
                                                                            AutoGenerateColumns="false" DataKeyNames="SalesID" ShowFooter="true">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Transid" Visible="false" DataField="SalesID" />
                                                                                <asp:BoundField HeaderText="Product" DataField="Definition" />
                                                                                <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                                                                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                                                <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' Visible="false" />
                                                                                
                                                                            </Columns>
                                                                            
    
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                                                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                                            <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                                            <asp:BoundField HeaderText="Bill Date" DataField="BillDate" Visible="false" />
                                                            <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' Visible="false" />
                                                            
                                                            
                                                            <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                             <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' Visible="false" />
                                                             <asp:BoundField HeaderText="Status" DataField="labl" /> 
                                                             <asp:BoundField HeaderText="Cancel status" DataField="cancelstatus" />
                                                               <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                                 <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />  
                                                                 <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                                                           
                                                        </Columns>
                                                        <HeaderStyle BackColor="#990000" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />
                                                       
                                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                    </asp:GridView>
                             
                                 <td id="refre" runat="server" visible="false">
                                 
                                 </td>
                               
                                </div>
                                        </div>
                                        </div>
                               

                               



                                     </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="display: none">

     <asp:Button ID="btnDummy" runat="server" Text="Button" />

</div>
                                     <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnDummy"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
                                       <asp:panel Width="30%" class="popupConfirmation" id="DivDeleteConfirmation"  
	style="display: none; background:#fffbd6"  runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div align="center"  style="color:Red" class="TitlebarLeft">
                Warning Message!!!(Your Process is Tracking Via Email)</div>
            <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div  align="center" style="color:Red" class="popup_Body">
         <asp:TextBox ID="txtRef" runat="server" Width="80%"  placeholder="Enter Mobile No OR Reference BillNo" ></asp:TextBox>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div class="header">
            Cancel Status
        </div>
        <div class="body" align="center">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table style="font-style: normal; background-color: ButtonHighlight" border="0" width="100%">
                     
                        <tr>
                        <td >
                        <div style="overflow:scroll; height:250px">
                          <asp:GridView ID="GridView1all" runat="server" CssClass="table table-hover" Width="100%" OnRowCommand="GridView1all_RowCommand"
                                        AutoGenerateColumns="false" GridLines="None" ShowHeader="true">
                                        <HeaderStyle BackColor="#785a39" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="KotNo"  HeaderText="Kot NO" />
                                            <asp:BoundField DataField="Definition" HeaderText="Definition" />
                                            <asp:BoundField DataField="AQty" HeaderText="Actual Qty" />
                                            <asp:BoundField DataField="Qty" HeaderText="Change Qty" />
                                            
                                            <asp:BoundField DataField="Amount" Visible="false" DataFormatString="{0:f}" HeaderText="Amount" />
                                            <asp:BoundField DataField="gst" DataFormatString="{0:f}" Visible="false" />
                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcategoryuserid" runat="server" Text='<%#Eval("categoryuserid")%>'
                                                        Style="display: none"></asp:Label>
                                                        <asp:Label ID="lblkotid" runat="server" Text='<%#Eval("kotid")%>'
                                                        Style="display: none"></asp:Label>
                                                        <asp:Label ID="lblAQty" runat="server" Text='<%#Eval("AQty")%>'
                                                        Style="display: none"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Minus">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgminus" runat="server" CommandName="minus" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                        Height="20px" Width="20px" ImageUrl="~/images/Minus.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                          
                                            <asp:TemplateField HeaderText="Cancel"  >
                                            <ItemTemplate>
                                            <asp:CheckBox ID="chkcancell" Checked='<%#Eval("check")%>' runat="server"  />
                                            
                                                                                        </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                    </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <div class="footer" align="right">
                <asp:Button ID="btnsettle" runat="server" CssClass="yes" Text="Save Kot-Bill" OnClick="KotBIll"  />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="no" />
            </div>
        </div>
    </asp:Panel>

                                   
                                    </form>
                                 
                             
                            <!-- /.row (nested) -->
                </div>
                        <!-- /.panel-body -->
            </div>
        
        
        </div>


        </div>  
    
     </div>     


</body>

</html>


