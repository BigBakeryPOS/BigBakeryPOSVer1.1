<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeRate.aspx.cs" Inherits="Billing.Accountsbootstrap.ChangeRate" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>
<style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Item Master </title>
   
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
<body style="">
<usc:Header ID="Header" runat="server" />
    

    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>

                    <form id="Form1" runat="server">
                     <asp:scriptmanager id="ScriptManager1" runat="server">
</asp:scriptmanager>
            <div>
            <br />
            Search Items
            <asp:TextBox ID="txtser" runat="server" Width="200px" Height="30px" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox>
            </div>
    <div id = "dvGrid" style ="padding:10px;width:550px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="GridView1" runat="server"  Width = "550px"
AutoGenerateColumns = "false" Font-Names = "Arial"
Font-Size = "15pt" AlternatingRowStyle-BackColor = "#C2D69B" 
HeaderStyle-BackColor = "green" HeaderStyle-ForeColor="White"   ShowFooter = "true" 
 onrowediting="EditCustomer"
onrowupdating="UpdateCustomer"  onrowcancelingedit="CancelEdit"
 >
<Columns>
<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "ItemId">
    <ItemTemplate>
        <asp:Label ID="lblItemId" runat="server"
        Text='<%# Eval("Categoryuserid")%>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtItemid" Width = "40px"
            MaxLength = "5" runat="server"></asp:TextBox>
    </FooterTemplate>
</asp:TemplateField>

<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Item">
    <ItemTemplate>
        <asp:Label ID="LblItem" runat="server"
        Text='<%# Eval("Definition")%>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtItem" Width = "40px"
            MaxLength = "5" runat="server"></asp:TextBox>
    </FooterTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "Amma Naana Rate">
    <ItemTemplate>
        <asp:Label ID="lblammaRate" runat="server"
                Text='<%# Eval("User1")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtammaRate" runat="server"
            Text='<%# Eval("User1")%>'></asp:TextBox>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txtammaRate" runat="server"></asp:TextBox>
    </FooterTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Pothys Rate">
    <ItemTemplate>
        <asp:Label ID="lblPothysRate" runat="server"
            Text='<%# Eval("User2")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtpothysRate" runat="server"
            Text='<%# Eval("User2")%>'></asp:TextBox>
    </EditItemTemplate> 
    <FooterTemplate>
        <asp:TextBox ID="txtpothysRate" runat="server"></asp:TextBox>
    </FooterTemplate>
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate >
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("Categoryuserid")%>'
         OnClientClick = "return confirm('Do you want to delete?')"
        Text = "Delete" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="btnAdd" runat="server" Text="Edit" 
            OnClick = "AddNewCustomer" />
    </FooterTemplate>
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>
<AlternatingRowStyle BackColor="#C2D69B"  />
</asp:GridView>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
</Triggers>
</asp:UpdatePanel>
</div>
                                </form>
                                
                                <!-- /.col-lg-6 (nested) -->
                                
                
		
		


</body>

</html>
