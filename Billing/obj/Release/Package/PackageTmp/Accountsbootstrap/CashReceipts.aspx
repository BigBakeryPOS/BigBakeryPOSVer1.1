<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashReceipts.aspx.cs" Inherits="Billing.Accountsbootstrap.CashReceipts" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Pending Receipt</title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Sales </title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
  <%--  <link rel="stylesheet" href="../css/chosen.css" />--%>

      <link href="../Accountsbootstrap/css/chosen.min.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function Denomination123() {


            var gridData = document.getElementById('IDValues');


            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();


            var prtWindow = window.open(windowUrl, windowName,
           'left=100,top=100,right=100,bottom=100,width=700,height=500');
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
    <script type="text/javascript">
        $(function () {
            $("[id*=btnShowPopup]").click(function () {
                ShowPopup();
                return false;
            });
        });
        function ShowPopup() {
            $("#dialog").dialog({
                title: "GridView",
                width: 450,
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        }
    </script>
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
</head>
<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .GridPager a, .GridPager span
    {
        display: block;
        height: 20px;
        width: 20px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }
    
    
    .mGrid
    {
        border-collapse: collapse;
        width: 100%;
        border: 1px solid gray;
        overflow: hidden;
        font-family: Calibri;
        font-size: medium;
        text-align: center;
    }
</style>

 <%--<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>--%>


<script type="text/javascript">
    function alertMessage() {
        alert('Are You Sure, You want to delete This Customer!');
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


    function Diaplay() {
        var div = document.getElementById("div");

        if (div.style.display == "none") {
            div.style.display = "inline";




        }
        else {
            div.style.display = "none";


        }
    }
</script>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="f1" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

 <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Customer Sales Receipt & Report</h1>
	    </div>

        <div class="panel-body">
            <div class="row">
              
                    <div class="col-lg-6">
                        <div class="col-lg-6">
                            <label>
                                Receipt No</label>
                            <asp:textbox id="txtBillNo" cssclass="form-control" runat="server" 
                                enabled="false">
                            </asp:textbox>
                    </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Paid Amount
                            </label>
                            <asp:textbox id="txtAmount" cssclass="form-control" runat="server" autopostback="true"
                                 enabled="false" ontextchanged="txtAmount_TextChanged">0.00</asp:textbox>
                     </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Bank Name
                            </label>
                            <asp:dropdownlist id="ddlbank" runat="server" cssclass="form-control">
                            </asp:dropdownlist>
                            <asp:textbox id="txtbank" cssclass="form-control" runat="server" enabled="false"
                                visible="false">
                            </asp:textbox>
                     </div>
                     <div class="col-lg-6">
                            <label style="color: Black;">
                                Cheque Date</label>
                            <asp:textbox id="txtchequedate" cssclass="form-control"  enabled="false"
                                runat="server">
                            </asp:textbox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" TargetControlID="txtchequedate"
                                Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                                CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Receipt Date</label>
                            <asp:textbox id="txtBillDate" cssclass="form-control"  runat="server">
                            </asp:textbox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate"
                                Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                                CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                     </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Close Discount
                            </label>
                            <asp:textbox id="txtCloseDiscount" cssclass="form-control" runat="server" 
                                enabled="false">0.00</asp:textbox>
                     </div>
                     <div class="col-lg-6">
                            <label>
                                Pay Mode</label>
                            <asp:dropdownlist id="ddlPayMode" autopostback="true" runat="server" cssclass="form-control"
                                onselectedindexchanged="ddlPayMode_OnSelectedIndexChanged" >
                            </asp:dropdownlist>
                     </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Cheque/UTR
                            </label>
                            <asp:textbox id="txtCheqeNo" cssclass="form-control" runat="server"
                                enabled="false">
                            </asp:textbox>
                       </div>
                     <div class="col-lg-6">
                            <label style="color: Black">
                                Customer
                            </label>
                            <asp:dropdownlist runat="server" id="ddlcustomer"  CssClass="form-control" autopostback="true"
                                onselectedindexchanged="ddlcustomer_OnSelectedIndexChanged">
                            </asp:dropdownlist>
                     </div>
                     <div class="col-lg-6">
                     <br />
                            <asp:button id="btnSubmit" runat="server" class="btn btn-primary pos-btn1" text="Process" onclientclick="return confirm('Please Check the Amount?');"
                                 onclick="Process_Click"  />
                           &nbsp;&nbsp;&nbsp; <asp:button id="Button1" runat="server" text="Export To Excel" visible="true" cssclass="btn btn-success"
                                onclick="btnExcel_Click1" />
                          &nbsp;&nbsp;&nbsp;  <asp:button id="btncalc" runat="server" class="btn btn-warning" text="Calc" onclick="btncalc_Click"
                                 />
                        </div>
                     
                    </div>
                    <div class="col-lg-6">
                        <div class="col-lg-6">
                            <label style="color: Black">
                                From Date</label>
                            <asp:textbox id="txtfromdate" cssclass="form-control" runat="server">
                            </asp:textbox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfromdate"
                                Format="dd/MM/yyyy" PopupButtonID="txtfromdate" runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                            </div>
                    <div class="col-lg-6">
                            <label style="color: Black">
                                Customer
                            </label>
                            <asp:dropdownlist runat="server" id="ddlcustomerrep" cssclass="form-control">
                            </asp:dropdownlist>
                       </div>
                    <div class="col-lg-6">
                            <label style="color: Black">
                                To Date</label>
                            <asp:textbox id="txttodate" cssclass="form-control" runat="server" >
                            </asp:textbox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txttodate"
                                Format="dd/MM/yyyy" PopupButtonID="txttodate" runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                         <div class="col-lg-6">
                         <label>
                                    Pay Mode</label>
                                <asp:dropdownlist id="ddlpay" runat="server" cssclass="form-control" >
                                </asp:dropdownlist>
                            </div>
                    <div class="col-lg-6">
                    <br />
                          
                            <asp:button id="btnsearch" runat="server" class="btn btn-primary pos-btn1" text="Search" onclick="btnsearch_OnClick" />
                            <asp:label id="lblPrint" runat="server"></asp:label>
                            
                           <asp:Label ID="lblreceipttype" runat="server" Text="WholeSales" Visible="false" ></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:button id="btn" runat="server" text="Print" visible="true" cssclass="btn btn-secondary"
                                onclientclick="Denomination123()" />
                     
                             
                            
                              
                             &nbsp;&nbsp;&nbsp;   <asp:button id="btnExcel" runat="server" text="Export To Excel" visible="true" cssclass="btn btn-success"
                                    onclick="btnExcel_Click"  />
                            </div>
                  </div>
              </div> 
              <div id="IDValues"  runat="server"> 
              <div class="col-lg-6">
                      <div class="table-responsive panel-grid-left">
                            <asp:gridview id="gv" emptydatatext="Oops! No Activity Performed." showfooter="true"
                                onrowdatabound="gvsales_OnRowDataBound" caption="Customer Cash Receive" cssClass="table table-striped pos-table"
                                 runat="server" padding="0" spacing="0" border="0"
                                autogeneratecolumns="false">
                                <PagerStyle CssClass="pos-paging" />
                               <%-- <pagerstyle horizontalalign="Left" cssclass="GridPager" />--%>
                                <columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesid" runat="server" Text='<%# Eval("salesid")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BillNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DCNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDCNo" runat="server" Text='<%# Eval("DCNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BillDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillDate" runat="server" Text='<%# Eval("BillDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillAmt" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paid Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidamt" runat="server" Text='<%# Eval("Paidamt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Return Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRtnamt" runat="server" Text='<%# Eval("ReturnAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="CreditNote">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreditNoteAmount" runat="server" Text='<%# Eval("CreditNoteAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Balance Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal1" runat="server" Text='<%# Eval("Total")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   

                                    <asp:TemplateField HeaderText="NetAmount" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total")%>' DataFormatString="{0:f}"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Amount Received">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpaid" runat="server" MaxLength="10" Enabled="true">0</asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid" runat="server"
                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtpaid" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Close Discount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtclosediscount" runat="server" MaxLength="4">0</asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid1" runat="server"
                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtclosediscount" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Narration">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNarration" runat="server" Text=""></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </columns>
                            </asp:gridview>
                            </div>
                        </div>
                        <div class="col-lg-6">
                             <div class="table-responsive panel-grid-left">
                            <asp:gridview id="gvreceiptamt" emptydatatext="Oops! No Activity Performed." cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                onrowcommand="gvsales_RowCommand" caption="Customer Payment Receipt" onrowdatabound="gvreceiptamt_OnRowDataBound"
                                runat="server" autogeneratecolumns="false" showfooter="true">
                                <columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ReceiptNo" DataField="ReceiptNo" />
                                    <asp:BoundField HeaderText="ReceiptDate" DataField="ReceiptDate" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" />
                                    <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="CloseDiscount" DataField="CloseDiscount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="PayMode" DataField="PayMode" />
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("ReceiptID") %>'
                                                CommandName="print">
                                                <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" Visible="false"/>
                                                <button type="button" class="btn btn-default btn-md">
						                            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                            </button>
                                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </columns>
                            </asp:gridview>
                            </div>
                        </div>
              </div>
                            <div class="col-lg-2">
                                <asp:textbox placeholder="Search Text" id="txtsearchmobile" style="height: 28px;"
                                    runat="server" cssclass="form-control" maxlength="25" visible="false" onkeyup="Search_Gridview(this, 'gv')">
                                </asp:textbox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ._/-"
                                    TargetControlID="txtsearchmobile" />
                            </div>
                
                            <div id="refund" runat="server" visible="false">
                                <asp:label id="Label1" runat="server" style="font-size: larger; font-weight: bold">Refund Amont:</asp:label>
                                <asp:label id="lblledgerbalance" runat="server" style="font-size: larger; font-weight: bold">0</asp:label>
                            </div>
                         
                       
                    </div>


  </div>
  </div>
  </div>
  </div>  
    
    
    </ContentTemplate>
    </asp:UpdatePanel>
  <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    </form>
</body>
</html>
