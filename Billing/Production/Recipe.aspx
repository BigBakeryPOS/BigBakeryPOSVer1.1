<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="Billing.Production.Recipe" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Gridstyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/myGridstyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#d6ecf7">
  <usc:Header ID="Header" runat="server" />   
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row" style="margin:50px" >
    <asp:Label ID="lblrecipe1" Text="Name" runat="server" ></asp:Label>
    </div>
   
   <div class="col-lg-12">
   <div class="col-lg-1">
   <div class="form-group">
  <label>Recipe Name</label>
   </div></div>
   <div class="col-lg-3" >
   <div class="form-group">
   <asp:TextBox ID="txtrecipe" Width="300px" Placeholder="Enter Recepi Name" CssClass="form-control" runat="server"></asp:TextBox>
   </div>
   </div>
      <div class="col-lg-3" >
        
   <asp:TextBox ID="txtcoefficient" Placeholder="Coefficient" Width="150px" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
  </div>
   <div class="form-group">
    <asp:GridView ID="recipegrid" CssClass="myGridStyle" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>
  <div class="col-lg-3"></div>
  <div class="row" style="margin-top:20px">
  <div class="col-lg-10">
  <div class="col-lg-3">
  <div class="form-group">
  
   <asp:DropDownList ID="ddlingredients"  Width="280px" CssClass="form-control" runat="server"></asp:DropDownList>
  </div>
   </div>
  
  <div class="col-lg-6">
  <div class="col-lg-6">
  <asp:TextBox ID="txtkg" Placeholder="Kg" Width="100px" CssClass="form-control" runat="server"></asp:TextBox>
  
  </div>
  <div class="col-lg-2">
  <asp:Button ID="Button1" runat="server" Text="Add" Width="100px" 
           CssClass="btn btn-primary" 
          onclick="Button1_Click" />
        </div>
     
 
  </div>
  </div>

 
</div>

   
    
   <div class="form-group">
   <label>How long until the dough is ready for baking (days)</label>
   <asp:TextBox ID="txtbakedays" CssClass="form-control" Width="150px" runat="server" Placeholder="Enter days"></asp:TextBox>
   </div>

    </form>
</body>
</html>
