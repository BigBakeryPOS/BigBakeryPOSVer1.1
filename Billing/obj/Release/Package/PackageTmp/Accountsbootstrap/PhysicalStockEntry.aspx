<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalStockEntry.aspx.cs" Inherits="Billing.Accountsbootstrap.PhysicalStockEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
<style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>
<style>
table  table thead
{
    display: block;
    position:relative;
}

</style>
 <SCRIPT language=Javascript>

     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
             return false;

         return true;
     }
       
    </SCRIPT>
    <title></title>
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="panel panel-body">
    <div class="col-lg-12" >
    <div class="col-lg-6" >
    <asp:TextBox ID="txtSearch" runat="server" Font-Size="20px" onkeyup="Search_Gridview(this, 'gvtransfer')"></asp:TextBox><br />
    <div class="table" style="height:500px;overflow:scroll" >
     
    <asp:GridView ID="gvtransfer" runat="server" AutoGenerateColumns="false" EnableViewState="true" HeaderStyle-BackColor="Red" HeaderStyle-ForeColor="White"  >
   <Columns>
   <asp:BoundField HeaderText="id" DataField="IngridID" />
   <asp:BoundField HeaderText="Category Name" DataField="IngreCategory" />
   
   <asp:BoundField HeaderText="Item Name" DataField="IngredientName" />
   <asp:BoundField HeaderText="Op Stock" DataField="Qty" />
   <asp:BoundField HeaderText="UOM" DataField="uom" />
   <asp:TemplateField HeaderText="Physical Stock">
   <ItemTemplate>
   <asp:Label ID="lbluomid" Visible="false" runat="server" Text='<%#Eval("uomid") %>' ></asp:Label>
   <asp:TextBox ID="txtphystock" runat="server" CssClass="form-control"   ></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ID="txtstock" ControlToValidate="txtphystock"
                                    ValidationGroup="val2" Text="*" ErrorMessage="Please enter your Category!" Style="color: Red" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterType="Numbers,Custom" ValidChars="-."
                                    TargetControlID="txtphystock" />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Exp date">
   <ItemTemplate>
    <asp:TextBox ID="txtexpireddate" runat="server" Enabled="true" Height="30px" Width="90px">0</asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtexpireddate"
                                                PopupButtonID="txtexpireddate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                                                CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
   </ItemTemplate>
   </asp:TemplateField>
 
   </Columns>
    </asp:GridView>
    </div>
    <div>
    <asp:Button ID="btnsend" runat="server" Text="Save" CssClass="btn btn-success" 
            onclick="btnsend_Click" />
    </div>
   
    </div>
    <div class="col-lg-6" >
    <div class="form-group">
                                                    <label>
                                                        Upload Data From Excel
                                                    </label>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                            <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                                OnClick="Async_Upload_File" />
                                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload_File" CssClass="btn btn-danger"/>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:GridView ID="GridView2" runat="server">
                                                    </asp:GridView>
                                                </div>
                                                <div>
                                                <label style="color:Red" >NOTE : This Missing Item Only For Temporary View Purpose So Please Copy And Paste in Your Excel Sheet</label><br />
                                                <label>Missing Items</label>
                                                
                                                <asp:GridView ID="gridmissitem" runat="server" EmptyDataText="No Missing Data Found" AutoGenerateColumns="false" >
                                                <Columns>
                                                <asp:BoundField DataField="Item" HeaderText="Missing Items" />
                                                <asp:BoundField DataField="Qty" HeaderText="OP Qty" DataFormatString='{0:d}' />
                                                </Columns>
                                                </asp:GridView>
                                                </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>

