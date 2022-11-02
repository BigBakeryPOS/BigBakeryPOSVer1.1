<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Waiter.aspx.cs" Inherits="Billing.Accountsbootstrap.Waiter" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
     <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title></title>

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
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    

    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <div >
                 
                    <div class="col-lg-12">

                    <div class="col-lg-6" >
                        <div class="panel panel-primary">
                              <div class="panel-heading">Supervisor Details</div>
                        <div class="panel-body">
                    <asp:TextBox ID="txtser" runat="server" Placeholder="Search Supervisor.." Width="150px" CssClass="form-control" onkeyup="Search_Gridview(this, 'gvs')" ></asp:TextBox>
 <br />   <asp:GridView ID="gvs" runat="server" CssClass="mGrid" AutoGenerateColumns="false" 
            onrowcommand="gvs_RowCommand" >
   <Columns>
   <asp:BoundField DataField="Empid" HeaderText="Empid" />
   <asp:BoundField DataField="Name" HeaderText="Name" />
   <asp:BoundField DataField="location" HeaderText="Location" />
   <asp:BoundField DataField="Role" HeaderText="Role" />
   <asp:BoundField DataField="Code" HeaderText="Code" />
   <asp:TemplateField  HeaderText="Edit">
   <ItemTemplate>
   
   <asp:Button ID="btnedit" runat="server"  Text="Edit" CssClass="btn btn-info"  CommandArgument='<%#Eval("Empid") %>' />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField  HeaderText="Delete">
   <ItemTemplate>
   <asp:Button ID="btndel" runat="server"  Text="Delete" CssClass="btn btn-danger" CommandName="RM"  CommandArgument='<%#Eval("Empid") %>' />
   </ItemTemplate>
   </asp:TemplateField>
   </Columns>
    </asp:GridView>
   </div>
   </div>
                    </div>
                    <div class="col-lg-6">
                     <div class="panel panel-primary">
                              <div class="panel-heading">Supervisor Master</div>
                        <div class="panel-body">
    <label> Name</label>
    <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
 
    <label> Role</label>
  <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
 <asp:ListItem Text="Billing"></asp:ListItem>
 <asp:ListItem Text="Cash"></asp:ListItem>
 <asp:ListItem Text="Sales"></asp:ListItem>
 <asp:ListItem Text="Livekitchen"></asp:ListItem>
  </asp:DropDownList>
   <br />
    <label> Location</label>
   <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
 <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
 <asp:ListItem Text="Byepass" Value="co2"></asp:ListItem>
 <asp:ListItem Text="BBK" Value="co3"></asp:ListItem>
  <asp:ListItem Text="Npuram" Value="co4"></asp:ListItem>
   <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
   <asp:ListItem Text="Chennai-Maduravayol" Value="co6"></asp:ListItem>
   <asp:ListItem Text="Chennai-Purasawalkam" Value="co7"></asp:ListItem>
   <asp:ListItem Text="Chennai-Pro" Value="Pro"></asp:ListItem>
   <asp:ListItem Text="Nellai-Pro" Value="Pro"></asp:ListItem>
   <asp:ListItem Text="Mdu-Pro" Value="Pro"></asp:ListItem>
  </asp:DropDownList>
  <br />
    <label> Code</label>
    <asp:TextBox ID="txtcode" runat="server" CssClass="form-control"></asp:TextBox>
   

    <br />
    <asp:Button ID="btnsave" runat="server" Text="Save"
         CssClass="btn btn-success" onclick="btnsave_Click" />
    </div></div></div></div>
                    
                    </div>
   

    

    </div>
    </form>
</body>
</html>
