<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stockReturn.aspx.cs" Inherits="Billing.Accountsbootstrap.stockReturn" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">


        function DisableButton() {
            alert("Processing...");
            document.getElementById("btnSave").click();
        }
        
    </script>
    <style>
        .ontop
        {
            z-index: 999;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            display: none;
            position: absolute;
            background-color: #cccccc;
            color: #aaaaaa;
            opacity: .4;
            filter: alpha(opacity = 50);
        }
        #popup
        {
            width: 300px;
            height: 200px;
            position: absolute;
            color: #000000;
            background-color: #ffffff; /* To align popup window at the center of screen*/
            top: 50%;
            left: 50%;
            margin-top: -100px;
            margin-left: -150px;
        }
    </style>
    <script type="text/javascript">
        function pop(div) {
            document.getElementById(div).style.display = 'block';
            document.getElementById("btnSave").click();
        }
        function hide(div) {
            document.getElementById(div).style.display = 'none';
        }
        //To detect escape button
        document.onkeydown = function (evt) {
            evt = evt || window.event;
            if (evt.keyCode == 27) {
                hide('popDiv');
            }
        };
    </script>
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";
            }
            return true;
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
 <%--   <asp:UpdatePanel ID="upanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <asp:ScriptManager ID="script" runat="server">
            </asp:ScriptManager>
            <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
            <div id="popDiv" class="ontop">
                <table border="1" id="popup" style="background-color: Red">
                    <tr>
                        <td align="center" style="color: White">
                            <b>Please Wait.................</b>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Return Entry</h1>
	    </div>
            <div class="panel-body">
                <div class="row">
                    
                       
                            <div class="col-lg-3">
                                
                                    <label>
                                        Return No</label>
                                    <asp:TextBox CssClass="form-control" ID="txtbillno" Enabled="false" runat="server"
                                        ></asp:TextBox>
                              
                            </div>
                            <div class="col-lg-3">
                                
                                    <label>
                                        Return Date</label>
                                    <asp:TextBox CssClass="form-control" ID="txtsdate1" runat="server" Text="-----Select Date-----"
                                         Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtsdate1"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                
                            </div>
                            <div  runat="server" visible="false">
                                
                                    <asp:Label runat="server" ID="Label1">Production Name </asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlvendor" class="form-control" 
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                               </div>
                           
                            <div class="col-lg-3">
                               
                                    <label>
                                        Reasons</label>
                                    <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" 
                                        AutoPostBack="true" OnSelectedIndexChanged="drpPayment_OnSelectedIndexChanged">
                                        <%--<asp:ListItem Text="Select Reasons" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="Wastage" Value="1" Enabled="false" ></asp:ListItem>
                                <asp:ListItem Text="DateBar" Value="2"></asp:ListItem>
                                 <asp:ListItem Text="Excess" Value="3" ></asp:ListItem>
                                <asp:ListItem Text="Damage" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Wrong GRN" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Shortage" Value="6" ></asp:ListItem>
  <asp:ListItem Text="Fungus" Value="7" ></asp:ListItem>
  <asp:ListItem Text="Fungus Before Date" Value="8" ></asp:ListItem>
  <asp:ListItem Text="To Production" Value="9" ></asp:ListItem>
   <asp:ListItem Text="Return To Production(Recycle)" Value="10" ></asp:ListItem>
   <asp:ListItem Text="Staff Consumed" Value="11" ></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="12" ></asp:ListItem>
                                <asp:ListItem Text="Stock (+)(-)" Value="13"></asp:ListItem>
                                <asp:ListItem Text="Stock Shift" Value="14"></asp:ListItem>
                                <asp:ListItem Text="Stock Consumed" Value="15"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                
                            </div>
                            <div class="col-lg-3">
                                
                                    <label>
                                        Sub Reasons</label>
                                    <asp:DropDownList ID="ddlsubreasons" runat="server" CssClass="form-control">
                                        <%--<asp:ListItem  Text="Stock Excess" Value="1" Enabled="false"></asp:ListItem>
 <asp:ListItem Text="Stock Shortage" Value="2" Enabled="false"></asp:ListItem>
 <asp:ListItem Text="Fungus" Value="3" Enabled="false"></asp:ListItem>
  <asp:ListItem Text="Fungus before Date" Value="4" Enabled="false"></asp:ListItem>
   <asp:ListItem Text="To Production" Value="5" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="To Pothys" Value="6" Enabled="false"></asp:ListItem>
     <asp:ListItem Text="Return To Production(Recycle)" Value="7" Enabled="false"></asp:ListItem>
      <asp:ListItem Text="Wrong GRN" Value="8" Enabled="false"></asp:ListItem>
      <asp:ListItem Text="Stock Consumed" Value="9" Enabled="false"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                
                            </div>
                            <div class="col-lg-3">
                               
                                    <label>
                                        Person Name</label>
                                    <asp:TextBox ID="txtreturningPerson" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                            
                            <div class="col-lg-3">
                                
                                    <label>
                                        Detailed Notes
                                    </label>
                                    <asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" CssClass="form-control"
                                       ></asp:TextBox>
                                
                            </div>
                        </div>

                            <div class="col-lg-3" runat="server" visible="false">
                                <asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" Width="200px"
                                    TextMode="MultiLine" Height="50px"></asp:TextBox>
                            </div>
                    
                    
                    
                        <div class="form-group" id="admin" runat="server">
                            <label>
                                Branch</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                <asp:ListItem Text="KKnagar" Value="co1"></asp:ListItem>
                                <asp:ListItem Text="Byepass" Value="co2"></asp:ListItem>
                                <asp:ListItem Text="BBKulam" Value="co3"></asp:ListItem>
                                <asp:ListItem Text="NP" Value="co4"></asp:ListItem>
                                <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                <asp:ListItem Text="Purawalkam" Value="co7"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      </div>
                      </div>
                        
               
                <div class="row">
                    <%--<table class="table" style="background-color: #ffb85f">--%>
                   <div class="col-lg-4">
        <div class="panel panel-custom1">
        <div class="panel-header">
				<h1 class="page-header">Add Return Stock</h1>
		</div>
         <div class="panel-body panel-form-right">
                <div class="list-group">
                                <label>
                                    Select Group</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlcat_selectedindexchanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                           <br />
                                <label>
                                    Select Item</label>
                                <asp:DropDownList ID="ddlitem" runat="server" CssClass="form-control" OnSelectedIndexChanged="dditem_selectedindexchanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                           <br />
                    <div class="col-lg-12">
                        <div class="col-lg-6">
                                <label>
                                    Available Qty</label>
                                <asp:TextBox ID="txtAvalQty" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,custom" TargetControlID="txtAvalQty" ValidChars=".">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                 <label>
                                    Return Qty</label>
                                <asp:TextBox ID="txtretQty" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="txtretQty_TextChanged"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterType="Numbers,custom" TargetControlID="txtretQty" ValidChars=".">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            <br />
                            </div>
                        <div class="col-lg-6">
                                <label>
                                    Rate</label>
                                <asp:TextBox ID="txtRate" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,custom" TargetControlID="txtRate" ValidChars=".">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                  <label>
                                    Amount</label>
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterType="Numbers,custom" TargetControlID="txtAmount" ValidChars=".">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            </div>
                                <asp:Label ID="lblcatid" runat="server" Style="display: none"></asp:Label>
                                <asp:Label ID="lblSubcatid" runat="server" Style="display: none"></asp:Label>
                                <asp:Label ID="stockid" runat="server" Style="display: none"></asp:Label>
                                <asp:Label ID="lblError" runat="server" Style="display: none"></asp:Label>
                           <br />
                                
                                <asp:ImageButton ID="img" runat="server" CssClass="btn btn-lg btn-primary pos-btn1" Width="70px" ImageUrl="~/images/add.jpg" 
                                    OnClick="add_click"  />
                        </div>
                        </div>    
                    </div>
                    </div>
                    <div class="col-lg-8">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">STOCK RETURN Details</h1>
	    </div>
        <div class="panel-body">
                     <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvItems" runat="server" Width="100%" OnRowDeleting="OnRowDeleting"
                                    OnRowDataBound="OnRowDataBound" AutoGenerateColumns="false" cssClass="table table-striped pos-table"  padding="0" spacing="0" border="0">
                                    <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubCatID" runat="server" Text='<%#Eval("SubCatID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-md"/>
                                        <asp:BoundField HeaderText="Group" DataField="Group" />
                                        <asp:BoundField HeaderText="Item" DataField="Item" />
                                        <asp:BoundField HeaderText="ExistQty" DataField="ExistQty" />
                                        <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                        <asp:BoundField HeaderText="Rate" DataField="Rate" />
                                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                        <asp:BoundField HeaderText="CatID" DataField="CatID" Visible="false" />
                                        <asp:BoundField HeaderText="SubCatID" DataField="SubCatID" Visible="false" />
                                        <asp:BoundField HeaderText="stockid" DataField="stockid" Visible="false" />
                                    </Columns>
                                </asp:GridView>
                           
                                Total
                                <asp:Label ID="total" runat="server">0</asp:Label>
                  </div>  
                   <asp:Button ID="btnSave" Text="Save" runat="server" 
            OnClick="btnSave_Click" OnClientClick="ClientSideClick(this)" CssClass="btn btn-lg btn-primary pos-btn1" UseSubmitBehavior="false"></asp:Button>
        <asp:Button ID="btnexit" Text="Clear" runat="server" CssClass="btn btn-lg btn-link" OnClick="btnexit_Click" />       
                </div>
                </div>
                </div>
            </div>
       
        </div>
        </div>
        </div>
        </div>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
