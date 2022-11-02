<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryChart.aspx.cs" Inherits="Billing.Accountsbootstrap.CategoryChart" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Category Chart</title>
</head>
<body>
           <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
  
    <form id="form1" runat="server">
     <usc:Header ID="Header" runat="server" />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     
    <ContentTemplate>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <table border="1">
    <tr><td height="70px"></td></tr>
    <tr>
    <td>Search by</td><td><asp:RadioButton ID="rdCat" GroupName="rdOption" Text="Category" AutoPostBack="true" runat="server" />
    <asp:RadioButton ID="rdMon" GroupName="rdOption" Text="Month" AutoPostBack="true" runat="server" />
    </td>
    </tr>
    </table>

    <table border="1" id="cat" runat="server" >
   <tr>
    <td>
       <asp:Chart ID="chart1"   runat="server" Width="700px"  Height="300px">
    <Titles>
        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)" 
            Text="Category by Quantity">
        </asp:Title>
    </Titles>
    <Series >
    <asp:Series Name="series" IsValueShownAsLabel="true"  XValueMember="Socks" IsVisibleInLegend="true" LegendText="Admin"  >
    <Points ></Points>
    </asp:Series>
    </Series>
     <Series>
    <asp:Series Name="series1" IsValueShownAsLabel="true" LegendText="Branch"  ></asp:Series>
    </Series>
     <Series>
    <asp:Series Name="series2" IsValueShownAsLabel="true"      LegendText="Dealer"  ></asp:Series>
    </Series>
    <Legends >
    <asp:Legend Name="Admin"></asp:Legend>
    </Legends>
     <chartareas>
        <asp:ChartArea    Name="ChartArea1">
       
        </asp:ChartArea>
        
    </chartareas>
    </asp:Chart>
    </td>
    <td >
    <table>
    <tr>
    <td>
     <asp:DropDownList ID="drpCategory" AutoPostBack="true" runat="server" 
            onselectedindexchanged="drpCategory_SelectedIndexChanged">
            <asp:ListItem Text="Select Category" Value="0"></asp:ListItem>
    <asp:ListItem Text="Socks" Value="1"></asp:ListItem>
    <asp:ListItem Text="Body Shape Cloth" Value="2"></asp:ListItem>
    <asp:ListItem Text="Sanitory Napkin" Value="3"></asp:ListItem>

    </asp:DropDownList></td>
    </tr>
    <tr><td>
        <asp:Chart ID="chart2"    runat="server" Width="650px"  Height="300px">
      <Titles>
        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)" 
           >
        </asp:Title>
    </Titles>
    <Series >
    <asp:Series Name="series" IsValueShownAsLabel="true"  XValueMember="Socks" IsVisibleInLegend="true"   >
    <Points ></Points>
    </asp:Series>
    </Series>
   
    <Legends >
    <asp:Legend Name="Admin"></asp:Legend>
    </Legends>
     <chartareas>
        <asp:ChartArea    Name="ChartArea1">
       
        </asp:ChartArea>
        
    </chartareas>
    </asp:Chart>
 
    </td></tr>

    </table>
   
    </td>
    </tr>
   
    </table>
 
   <table border="1" id="mon" runat="server" >
  
    <tr>
    <td>
       <asp:Chart ID="chart3"   runat="server" Width="1350px"  Height="300px">
    <Titles>
        <asp:Title Font="Times New Roman, 12pt, style=Bold, Italic" Name="Sales - Socks (NR)" 
            Text="Category by Quantity">
        </asp:Title>
    </Titles>
    <Series >
    <asp:Series Name="series" IsValueShownAsLabel="true"    IsVisibleInLegend="true" LegendText="Admin"  >
    <Points ></Points>
    </asp:Series>
    </Series>
     <Series >
    <asp:Series Name="series1" IsValueShownAsLabel="true"     IsVisibleInLegend="true" LegendText="Branch"  >
    <Points ></Points>
    </asp:Series>
    </Series>
     <Series >
    <asp:Series Name="series2" IsValueShownAsLabel="true"   IsVisibleInLegend="true" LegendText="Dealer"  >
    <Points ></Points>
    </asp:Series>
    </Series>
    
    <Legends >
    <asp:Legend Name="Admin"></asp:Legend>
    </Legends>
     <chartareas>
        <asp:ChartArea    Name="ChartArea1">
        
       <AxisX   Interval="1"   IntervalType="Number"  ArrowStyle="Triangle" ></AxisX>
  <AxisY   IsStartedFromZero="true"  IsLabelAutoFit="true" ArrowStyle="Triangle" > </AxisY>

        </asp:ChartArea>
        
    </chartareas>
    </asp:Chart>
    </td>
   
    </tr>
   
    </table>
 
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
